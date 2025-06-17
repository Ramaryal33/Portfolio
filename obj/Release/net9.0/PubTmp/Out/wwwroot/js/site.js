// Language Slider Animation
document.addEventListener('DOMContentLoaded', function () {
    const slider = document.querySelector('.language-slider');
    if (!slider) return;

    const languages = slider.dataset.languages.split(',');
    let currentIndex = 0;

    // Initial display
    slider.textContent = languages[currentIndex];
    slider.style.opacity = 1;

    function rotateLanguages() {
        // Fade out
        slider.style.opacity = 0;

        setTimeout(() => {
            // Change text and fade in
            currentIndex = (currentIndex + 1) % languages.length;
            slider.textContent = languages[currentIndex];
            slider.style.opacity = 1;
        }, 500); // Half of the transition time
    }

    // Rotate every 2 seconds
    setInterval(rotateLanguages, 2000);
});

// Letter-by-Letter Animation for "Full Stack Developer"
document.addEventListener("DOMContentLoaded", function () {
    const target = document.getElementById("animated-role");
    const text = "Full Stack Developer";
    let delay = 100; // milliseconds

    text.split("").forEach((char, index) => {
        const span = document.createElement("span");
        span.textContent = char;
        span.style.opacity = 0;
        span.style.transition = "opacity 0.3s ease";
        setTimeout(() => {
            target.appendChild(span);
            requestAnimationFrame(() => {
                span.style.opacity = 1;
            });
        }, delay * index);
    });
});
