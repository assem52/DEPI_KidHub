import config from './config.js';
import { loadingIndicator, errorHandler, storageHelper } from './utils.js';

class ApiService {
    constructor() {
        this.baseUrl = config.api.baseUrl;
        this.endpoints = config.api.endpoints;
        this.cache = new Map();
    }

    async makeRequest(endpoint, options = {}) {
        try {
            const token = localStorage.getItem('token');
            const headers = {
                'Content-Type': 'application/json',
                ...(token && { [config.api.authToken.header]: `${config.api.authToken.prefix} ${token}` }),
                ...options.headers
            };

            console.log('Making API request to:', `${this.baseUrl}${endpoint}`);
            console.log('Request options:', { ...options, headers: { ...headers, Authorization: '***' } });

            const response = await fetch(`${this.baseUrl}${endpoint}`, {
                ...options,
                headers
            });

            const data = await response.json();
            console.log('API Response:', data);

            if (!response.ok) {
                throw new Error(data.message || 'API request failed');
            }

            return data;
        } catch (error) {
            console.error('API Error:', error);
            throw error;
        }
    }

    // Auth Methods
    async login(email, password) {
        return this.makeRequest(this.endpoints.auth.login, {
            method: 'POST',
            body: JSON.stringify({ email, password })
        });
    }

    async register(userData) {
        return this.makeRequest(this.endpoints.auth.register, {
            method: 'POST',
            body: JSON.stringify(userData)
        });
    }

    async logout() {
        return this.makeRequest(this.endpoints.auth.logout, {
            method: 'POST'
        });
    }

    // Course Methods
    async getCourses() {
        return this.makeRequest(this.endpoints.courses.getAll);
    }


    

    // User Methods
    
    async getUserByEmail(email) {
        return this.makeRequest(this.endpoints.user.getByEmail(email));
    }

    // Lesson Methods
    async getAllLessons() {
        return this.makeRequest(this.endpoints.lessons.getAll);
    }

    async getLessonById(id) {
        return this.makeRequest(this.endpoints.lessons.getById(id));
    }

    async createLesson(lessonData) {
        return this.makeRequest(this.endpoints.lessons.create, {
            method: 'POST',
            body: JSON.stringify(lessonData)
        });
    }

    // Course Methods
    async getAllCourses() {
        return this.makeRequest(this.endpoints.courses.getAll);
    }

    async getCourseById(id) {
        return this.makeRequest(this.endpoints.courses.getById(id));
    }

    async createCourse(courseData) {
        return this.makeRequest(this.endpoints.courses.create, {
            method: 'POST',
            body: JSON.stringify(courseData)
        });
    }

    // Clear cache
    clearCache() {
        this.cache.clear();
    }
}

// Initialize API service
const apiService = new ApiService();
export default apiService;