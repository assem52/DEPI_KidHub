document.addEventListener('DOMContentLoaded', () => {
    // Load user data
    const user = JSON.parse(localStorage.getItem('user'));
    if (!user) {
        window.location.href = 'login.html';
        return;
    }

    // Update profile information
    document.querySelector('.student-name').textContent = user.name;
    document.querySelector('.student-email').textContent = user.email;
    
    // Update personal information
    const infoItems = document.querySelectorAll('.info-item');
    infoItems.forEach(item => {
        const label = item.querySelector('.info-label').textContent;
        const value = item.querySelector('.info-value');
        
        if (label.includes('Name')) {
            value.textContent = user.name;
        } else if (label.includes('Email')) {
            value.textContent = user.email;
        } else if (label.includes('Phone')) {
            value.textContent = user.phone;
        } else if (label.includes('Level')) {
            value.textContent = user.education;
        }
    });

    // Profile Image Upload
    const editProfileBtn = document.querySelector('.edit-profile-btn');
    const profileImage = document.querySelector('.profile-image img');
    
    editProfileBtn.addEventListener('click', () => {
        const input = document.createElement('input');
        input.type = 'file';
        input.accept = 'image/*';
        
        input.addEventListener('change', (e) => {
            const file = e.target.files[0];
            if (file) {
                const reader = new FileReader();
                reader.onload = (e) => {
                    profileImage.src = e.target.result;
                    // Store the image in localStorage
                    localStorage.setItem('profileImage', e.target.result);
                    alert(currentLang === 'en' ? 'Profile image updated successfully!' : 'تم تحديث صورة الملف الشخصي بنجاح!');
                };
                reader.readAsDataURL(file);
            }
        });
        
        input.click();
    });

    // Load profile image if exists
    const savedImage = localStorage.getItem('profileImage');
    if (savedImage) {
        profileImage.src = savedImage;
    }

    // Edit Information
    const editInfoBtn = document.querySelector('.edit-info-btn');
    
    editInfoBtn.addEventListener('click', () => {
        const isEditing = editInfoBtn.classList.toggle('editing');
        
        if (isEditing) {
            editInfoBtn.textContent = currentLang === 'en' ? 'Save Changes' : 'حفظ التغييرات';
            infoItems.forEach(item => {
                const value = item.querySelector('.info-value');
                const currentValue = value.textContent;
                const input = document.createElement('input');
                input.type = 'text';
                input.value = currentValue;
                input.className = 'info-input';
                value.replaceWith(input);
            });
        } else {
            editInfoBtn.textContent = currentLang === 'en' ? 'Edit Information' : 'تعديل المعلومات';
            const updatedUser = { ...user };
            
            infoItems.forEach(item => {
                const input = item.querySelector('.info-input');
                const newValue = input.value;
                const value = document.createElement('span');
                value.className = 'info-value';
                value.textContent = newValue;
                input.replaceWith(value);

                // Update user object
                const label = item.querySelector('.info-label').textContent;
                if (label.includes('Name')) {
                    updatedUser.name = newValue;
                } else if (label.includes('Email')) {
                    updatedUser.email = newValue;
                } else if (label.includes('Phone')) {
                    updatedUser.phone = newValue;
                } else if (label.includes('Level')) {
                    updatedUser.education = newValue;
                }
            });

            // Update localStorage
            localStorage.setItem('user', JSON.stringify(updatedUser));
            alert(currentLang === 'en' ? 'Information updated successfully!' : 'تم تحديث المعلومات بنجاح!');
        }
    });

    // Course Progress Animation
    const progressBars = document.querySelectorAll('.progress');
    
    const observerOptions = {
        threshold: 0.5
    };

    const progressObserver = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                const progress = entry.target;
                const width = progress.style.width;
                progress.style.width = '0';
                setTimeout(() => {
                    progress.style.width = width;
                }, 100);
            }
        });
    }, observerOptions);

    progressBars.forEach(bar => {
        progressObserver.observe(bar);
    });

    // Continue Learning Button
    const continueBtns = document.querySelectorAll('.continue-btn');
    
    continueBtns.forEach(btn => {
        btn.addEventListener('click', () => {
            const courseCard = btn.closest('.course-card');
            const courseName = courseCard.querySelector('h3').textContent;
            // Here you would typically redirect to the course content
            alert(currentLang === 'en' 
                ? `Continuing with ${courseName}` 
                : `المتابعة مع ${courseName}`);
        });
    });

    // Add styles for editing mode
    const style = document.createElement('style');
    style.textContent = `
        .info-input {
            width: 100%;
            padding: 0.5rem;
            border: 2px solid var(--primary-color);
            border-radius: 5px;
            background-color: var(--bg-color);
            color: var(--text-color);
        }
        
        .editing {
            background-color: var(--primary-color);
            color: white;
        }
    `;
    document.head.appendChild(style);
}); 