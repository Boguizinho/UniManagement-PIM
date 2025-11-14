
document.addEventListener('DOMContentLoaded', function () {
    // --- Elementos da página ---
    const chatBox = document.getElementById('chatBox');
    const chatInput = document.getElementById('chatInput');
    const sendMessageButton = document.getElementById('sendMessageButton');


    // --- URL da API ---
    const API_BASE_URL = 'https://localhost:7004/api/chamados'; // Ajuste a porta se necessário

    // --- Funções Auxiliares ---
    function addMessage(sender, message, isUser = false) {
        const messageElement = document.createElement('div');
        messageElement.classList.add('chat-message');
        messageElement.classList.add(isUser ? 'user-message' : 'ai-message');
        messageElement.innerHTML = `<strong>${sender}:</strong> ${message}`;
        chatBox.appendChild(messageElement);
        chatBox.scrollTop = chatBox.scrollHeight;
    }

    // --- Carregar Chamados Iniciais (GET) ---
    async function carregarChamadosIniciais() {
        addMessage('IA', 'Verificando o sistema...');
        try {
            const response = await fetch(API_BASE_URL); // GET por padrão
            if (!response.ok) throw new Error(`Erro ${response.status}`);
            const chamados = await response.json();

            if (chamados && chamados.length > 0) {
                let abertos = chamados.filter(c => c.status && c.status.toLowerCase() === 'aberto');
                addMessage('IA', `Encontrei ${chamados.length} chamado(s) no total. ${abertos.length} estão abertos.`);
            } else {
                addMessage('IA', 'Não há chamados registrados no momento.');
            }
        } catch (error) {
            addMessage('IA', `Falha ao buscar chamados: ${error.message}. A API está rodando?`);
        }
    }

    // --- Processar Mensagem do Usuário (POST para abrir chamado) ---
    async function processUserMessage(message) {
        addMessage('Você', message, true);
        chatInput.value = '';
        chatInput.disabled = true; // Desabilita enquanto a IA pensa
        sendMessageButton.disabled = true;

        try {
            // Envia a descrição para o endpoint POST da API
            const response = await fetch(`${API_BASE_URL}/abrir`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                // Enviamos a descrição e um ID de usuário fixo (para demonstração)
                body: JSON.stringify({
                    Descricao: message,
                    Id_Matricula_Funcionario: 1, // <-- Mude isso no futuro para o ID real
                    Prioridade: "Média" // Pode definir aqui ou deixar o backend decidir
                })
            });

            if (!response.ok) {
                throw new Error(`Erro ${response.status} ao contatar a API.`);
            }

            const data = await response.json(); // Lê a resposta da API

            // Verifica o 'status' retornado pela API
            if (data.status === 'sugestao') {
                addMessage('IA', `Sugestão: ${data.mensagem}`);
              
            } else if (data.status === 'aberto') {
                addMessage('IA', data.mensagem); // Exibe a mensagem "Chamado #XXX aberto..."
            } else {
                addMessage('IA', 'Recebi uma resposta inesperada da API.');
            }

        } catch (error) {
            addMessage('IA', `Erro ao processar sua solicitação: ${error.message}`);
        } finally {
            chatInput.disabled = false; // Reabilita o input
            sendMessageButton.disabled = false;
            chatInput.focus(); // Coloca o cursor de volta no input
        }
    }

    // --- Event Listeners ---
    sendMessageButton.addEventListener('click', function () {
        const message = chatInput.value.trim();
        if (message) {
            processUserMessage(message);
        }
    });

    chatInput.addEventListener('keypress', function (e) {
        if (e.key === 'Enter') {
            sendMessageButton.click();
        }
    });

    // --- Iniciar Conversa ---
    async function startAIChat() {
        addMessage('IA', 'Olá! Eu sou sua assistente virtual.');
        await carregarChamadosIniciais(); // Busca chamados existentes
        addMessage('IA', 'Como posso te ajudar hoje? Por favor, descreva seu problema.');
        chatInput.focus();
    }

    startAIChat(); // Inicia o chat ao carregar a página
});
