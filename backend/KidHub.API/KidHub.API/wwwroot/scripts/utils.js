// Loading Indicator
class LoadingIndicator {
    constructor() {
        this.loadingElement = document.createElement('div');
        this.loadingElement.className = 'loading-indicator';
        this.loadingElement.innerHTML = `
            <div class="spinner"></div>
            <p class="loading-text" data-en="Loading..." data-ar="جاري التحميل...">Loading...</p>
        `;
        document.body.appendChild(this.loadingElement);
    }

    show() {
        this.loadingElement.style.display = 'flex';
    }

    hide() {
        this.loadingElement.style.display = 'none';
    }
}

// Error Handler
class ErrorHandler {
    static showError(message, duration = 3000) {
        const errorElement = document.createElement('div');
        errorElement.className = 'error-message';
        errorElement.textContent = message;
        document.body.appendChild(errorElement);

        setTimeout(() => {
            errorElement.remove();
        }, duration);
    }

    static handleApiError(error) {
        console.error('API Error:', error);
        const message = error.message || 'An error occurred';
        this.showError(message);
    }
}

// Local Storage Helper
class StorageHelper {
    static getItem(key) {
        try {
            return JSON.parse(localStorage.getItem(key));
        } catch (error) {
            return null;
        }
    }

    static setItem(key, value) {
        try {
            localStorage.setItem(key, JSON.stringify(value));
            return true;
        } catch (error) {
            console.error('Storage Error:', error);
            return false;
        }
    }

    static removeItem(key) {
        localStorage.removeItem(key);
    }
}

// Export utilities
export const loadingIndicator = new LoadingIndicator();
export const errorHandler = ErrorHandler;
export const storageHelper = StorageHelper; 