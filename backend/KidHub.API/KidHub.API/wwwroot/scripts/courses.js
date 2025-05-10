
 
new Swiper('.card-wrapped', {
    loop: true,
  
    slidesPerView: 3,        // Show 3 cards at a time
    slidesPerGroup: 1,       // Move 1 card per swipe
    spaceBetween: 20,        // Optional: adds spacing between cards
  
    // pagination bullets
    pagination: {
      el: '.swiper-pagination',
      clickable: true,
      dynamicBullets: true
    },
  
    // Navigation arrows
    navigation: {
      nextEl: '.swiper-button-next',
      prevEl: '.swiper-button-prev',
    },
  
    // Optional responsive breakpoints
    breakpoints: {
      0: {
        slidesPerView: 1,
        slidesPerGroup: 1,
      },
      768: {
        slidesPerView: 2,
        slidesPerGroup: 1,
      },
      1024: {
        slidesPerView: 3,
        slidesPerGroup: 1,
      }
    }
  });
  