const config = {
    // API Endpoints
    api: {
        baseUrl: 'http://localhost:5276/api',
        endpoints: {
            auth: {
                login: '/User/login',        // Changed from '/auth/login'
                register: '/User/register',  // Changed from '/auth/register'
                logout: '/User/logout'       // Changed from '/auth/logout'
            },
            courses: {
                getAll: '/courses',
                getFeatured: '/courses/featured',
                getRecommended: '/courses/recommended',
                enroll: '/courses/enroll',
                getById: (id) => `/courses/${id}`,
                create: '/courses'
            },
            lessons: {
                getAll: '/Lesson',  // Same endpoints as courses
                getById: (id) => `/Lesson/${id}`,
                create: '/Lesson'
            },
            user: {
                profile: '/User/profile',
                enrolledCourses: '/User/courses',
                updateProfile: '/User/profile',
                getByEmail: (email) => `/User/email/${email}`  // Added this endpoint
            }
        },
        authToken: {
            header: 'Authorization',
            prefix: 'Bearer'
        }
    },
    
    // Authentication
    auth: {
        tokenKey: 'auth_token',
        refreshTokenKey: 'refresh_token',
        tokenExpiry: 3600 // 1 hour in seconds
    },
    
    // Localization
    localization: {
        defaultLanguage: 'en',
        supportedLanguages: ['en', 'ar']
    },
    
    // Theme
    defaultTheme: 'light',
    
    // Pagination
    pagination: {
        itemsPerPage: 12,
        maxPages: 5
    }
};

export default config; 