let slideIndex = 0; // Thay đổi slideIndex từ 1 thành 0 để bắt đầu từ slide đầu tiên
showSlides();

function plusSlides(n) {
  showSlides((slideIndex += n));
}

function currentSlide(n) {
  showSlides((slideIndex = n));
}

function showSlides() {
  let i;
  let slides = document.getElementsByClassName("mySlides");
  if (slideIndex >= slides.length) {
    slideIndex = 0; // Nếu slideIndex vượt quá số lượng slide thì quay lại slide đầu tiên
  }
  if (slideIndex < 0) {
    slideIndex = slides.length - 1; // Nếu slideIndex nhỏ hơn 0 thì quay lại slide cuối cùng
  }
  for (i = 0; i < slides.length; i++) {
    slides[i].style.display = "none";
  }
  slides[slideIndex].style.display = "block";
  slideIndex++;

  // Gọi lại hàm showSlides sau 3 giây
  setTimeout(showSlides, 10000);
}
