const config = {
    // API Endpoints
    api: {
        baseUrl: 'http://your-backend-url/api',
        endpoints: {
            auth: {
                login: '/auth/login',
                register: '/auth/register',
                logout: '/auth/logout'
            },
            courses: {
                getAll: '/courses',
                getFeatured: '/courses/featured',
                getRecommended: '/courses/recommended',
                enroll: '/courses/enroll'
            },
            user: {
                profile: '/user/profile',
                enrolledCourses: '/user/courses',
                updateProfile: '/user/update'
            }
        }
    },
    
    // Authentication
    auth: {
        tokenKey: 'auth_token',
        refreshTokenKey: 'refresh_token',
        tokenExpiry: 3600 // 1 hour in seconds
    },
    
    // Localization
    defaultLanguage: 'en',
    supportedLanguages: ['en', 'ar', 'fr'],
    
    // Theme
    defaultTheme: 'light',
    
    // Pagination
    pagination: {
        itemsPerPage: 12,
        maxPages: 5
    }
};

export default config; 