// payment.js
document.addEventListener('DOMContentLoaded', function() {
    // Get form elements
    const paymentForm = document.getElementById('paymentForm');
    const cardNumber = document.getElementById('cardNumber');
    const expiryDate = document.getElementById('expiryDate');
    const cvv = document.getElementById('cvv');
    const cardholderName = document.getElementById('cardholderName');
    const billingAddress = document.getElementById('billingAddress');
    const city = document.getElementById('city');
    const postalCode = document.getElementById('postalCode');
    const country = document.getElementById('country');
    const terms = document.getElementById('terms');
    const paymentButton = document.querySelector('.payment-button');

    // Format card number with spaces
    cardNumber.addEventListener('input', function(e) {
        let value = e.target.value.replace(/\s+/g, '').replace(/[^0-9]/gi, '');
        let formattedValue = '';
        for(let i = 0; i < value.length; i++) {
            if(i > 0 && i % 4 === 0) {
                formattedValue += ' ';
            }
            formattedValue += value[i];
        }
        e.target.value = formattedValue;
        validateCardNumber(value);
    });

    // Format expiry date
    expiryDate.addEventListener('input', function(e) {
        let value = e.target.value.replace(/\s+/g, '').replace(/[^0-9]/gi, '');
        if(value.length >= 2) {
            value = value.slice(0,2) + '/' + value.slice(2);
        }
        e.target.value = value;
        validateExpiryDate(value);
    });

    // Only allow numbers in CVV
    cvv.addEventListener('input', function(e) {
        e.target.value = e.target.value.replace(/[^0-9]/gi, '');
        validateCVV(e.target.value);
    });

    // Validate card number
    function validateCardNumber(number) {
        const cardNumberError = document.getElementById('cardNumberError') || createErrorElement(cardNumber);
        if(number.length < 16) {
            cardNumberError.textContent = 'Card number must be 16 digits';
            return false;
        }
        cardNumberError.textContent = '';
        return true;
    }

    // Validate expiry date
    function validateExpiryDate(date) {
        const expiryError = document.getElementById('expiryDateError') || createErrorElement(expiryDate);
        const [month, year] = date.split('/');
        
        if(!month || !year) {
            expiryError.textContent = 'Please enter a valid date (MM/YY)';
            return false;
        }

        const currentDate = new Date();
        const currentYear = currentDate.getFullYear() % 100;
        const currentMonth = currentDate.getMonth() + 1;

        if(month < 1 || month > 12) {
            expiryError.textContent = 'Invalid month';
            return false;
        }

        if(year < currentYear || (year == currentYear && month < currentMonth)) {
            expiryError.textContent = 'Card has expired';
            return false;
        }

        expiryError.textContent = '';
        return true;
    }

    // Validate CVV
    function validateCVV(cvv) {
        const cvvError = document.getElementById('cvvError') || createErrorElement(cvv);
        if(cvv.length < 3) {
            cvvError.textContent = 'CVV must be 3 digits';
            return false;
        }
        cvvError.textContent = '';
        return true;
    }

    // Create error element
    function createErrorElement(inputElement) {
        const errorElement = document.createElement('div');
        errorElement.className = 'error-message';
        errorElement.id = inputElement.id + 'Error';
        inputElement.parentNode.appendChild(errorElement);
        return errorElement;
    }

    // Show loading state
    function showLoading() {
        paymentButton.disabled = true;
        paymentButton.innerHTML = '<i class="fas fa-spinner fa-spin"></i> Processing...';
    }

    // Hide loading state
    function hideLoading() {
        paymentButton.disabled = false;
        paymentButton.innerHTML = '<span>Pay $79.99</span><i class="fas fa-lock"></i>';
    }

    // Show success message
    function showSuccess() {
        const successMessage = document.createElement('div');
        successMessage.className = 'success-message';
        successMessage.innerHTML = `
            <i class="fas fa-check-circle"></i>
            <h3>Payment Successful!</h3>
            <p>Thank you for your purchase. You will receive a confirmation email shortly.</p>
        `;
        paymentForm.innerHTML = '';
        paymentForm.appendChild(successMessage);
    }

    // Form submission
    paymentForm.addEventListener('submit', async function(e) {
        e.preventDefault();

        // Validate all fields
        const isCardNumberValid = validateCardNumber(cardNumber.value.replace(/\s+/g, ''));
        const isExpiryValid = validateExpiryDate(expiryDate.value);
        const isCVVValid = validateCVV(cvv.value);
        const isTermsChecked = terms.checked;

        if(!isCardNumberValid || !isExpiryValid || !isCVVValid || !isTermsChecked) {
            return;
        }

        // Show loading state
        showLoading();

        try {
            // Simulate API call
            await new Promise(resolve => setTimeout(resolve, 2000));
            
            // Show success message
            showSuccess();
        } catch (error) {
            console.error('Payment failed:', error);
            // Show error message
            const errorMessage = document.createElement('div');
            errorMessage.className = 'error-message';
            errorMessage.textContent = 'Payment failed. Please try again.';
            paymentForm.insertBefore(errorMessage, paymentButton);
        } finally {
            hideLoading();
        }
    });
});