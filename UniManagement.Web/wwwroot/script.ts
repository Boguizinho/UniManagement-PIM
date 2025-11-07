
console.log("O script.ts (compilado para .js) está sendo executado!");

interface UserData {
    id: string;
    phone: string;
    email: string;
    password: string; // Adicionando a senha à interface (ATENÇÃO: RISCO DE SEGURANÇA!)
}

document.addEventListener('DOMContentLoaded', function() {
    const loginForm = document.getElementById('loginForm');
    if (!loginForm) {
        console.error('Login form not found.');
        return;
    }
    loginForm.addEventListener('submit', function(event) {
        event.preventDefault(); // Prevent default form submission

        const usernameInput = document.getElementById('username') as HTMLInputElement;
        const passwordInput = document.getElementById('password') as HTMLInputElement;
        const errorMessage = document.getElementById('errorMessage');

        if (!usernameInput || !passwordInput || !errorMessage) {
            console.error('One or more required elements not found.');
            return;
        }

        // Admin credentials (fixed)
        const adminUsername = 'ADM@unimanagement';
        const adminPassword = 'adm123';

        // Registered user credentials (from localStorage)
        const storedUserData = localStorage.getItem('registeredUser');
        let registeredUser: UserData | null = null;
        if (storedUserData) {
            registeredUser = JSON.parse(storedUserData) as UserData;
        }

        // Check for Admin Login
        if (usernameInput.value === adminUsername && passwordInput.value === adminPassword) {
            errorMessage.textContent = 'Login de Administrador bem-sucedido! Redirecionando...';
            errorMessage.style.color = '#d4edda'; // Green color for success
            window.location.href = 'chamados.html';
        } 
        // Check for Registered User Login
        else if (registeredUser && 
                   (usernameInput.value === registeredUser.id || usernameInput.value === registeredUser.email) &&
                   passwordInput.value === registeredUser.password) { 
            errorMessage.textContent = 'Login de Usuário Registrado bem-sucedido! Redirecionando...';
            errorMessage.style.color = '#d4edda'; // Green color for success
            window.location.href = 'chamados.html';
        }
        // Invalid Credentials
        else {
            errorMessage.textContent = 'ID Do Usuário/E-mail ou Senha inválidos. Por favor, tente novamente.';
            errorMessage.style.color = '#FF0000'; // Red color for error
        }
    });
});
