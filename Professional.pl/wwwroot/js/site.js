document.addEventListener('DOMContentLoaded', () => {

    // ═══ DARK MODE ═══
    const themeToggle = document.getElementById('theme-toggle');
    const currentTheme = localStorage.getItem('theme') || 'light';
    document.documentElement.setAttribute('data-theme', currentTheme);
    if (themeToggle) {
        themeToggle.addEventListener('click', () => {
            const theme = document.documentElement.getAttribute('data-theme');
            const newTheme = theme === 'light' ? 'dark' : 'light';
            document.documentElement.setAttribute('data-theme', newTheme);
            localStorage.setItem('theme', newTheme);
        });
    }

    // ═══ INTERSECTION OBSERVER — كل الأنيميشن ═══
    const animObserver = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (!entry.isIntersecting) return;
            const delay = parseInt(entry.target.dataset.delay || 0);
            setTimeout(() => {
                entry.target.classList.add('in-view');
                entry.target.classList.add('active');
            }, delay * 150);
            animObserver.unobserve(entry.target);
        });
    }, { threshold: 0.12 });

    document.querySelectorAll(
        '.anim-fadeUp, .anim-fadeLeft, .anim-fadeRight, .anim-scaleIn, .anim-slideDown, .reveal, .reveal-footer'
    ).forEach(el => animObserver.observe(el));

    // ═══ STATS COUNTER ═══
    const counterObserver = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (!entry.isIntersecting) return;
            const el = entry.target;
            const target = parseFloat(el.dataset.target || el.dataset.count || 0);
            const isDecimal = String(target).includes('.');
            let current = 0;
            const increment = target / 60;
            const timer = setInterval(() => {
                current += increment;
                if (current >= target) {
                    current = target;
                    clearInterval(timer);
                    el.textContent = isDecimal ? current.toFixed(1) : '+' + Math.floor(current);
                } else {
                    el.textContent = isDecimal ? current.toFixed(1) : Math.ceil(current);
                }
            }, 30);
            counterObserver.unobserve(el);
        });
    }, { threshold: 0.5 });

    document.querySelectorAll('.counter, [data-target], [data-count]')
        .forEach(el => counterObserver.observe(el));

    // ═══ SECTION TAG UNDERLINE ═══
    const tagObserver = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.classList.add('active');
                tagObserver.unobserve(entry.target);
            }
        });
    }, { threshold: 0.8 });
    document.querySelectorAll('.section-tag-v2').forEach(el => tagObserver.observe(el));

    // ═══ SCROLL — Navbar + Progress + BackToTop ═══
    const navbar = document.querySelector('.navbar-custom');
    const logo = document.querySelector('.pro-logo');
    const backToTop = document.querySelector('.back-to-top');
    const progressBar = document.querySelector('.scroll-progress-bar');

    window.addEventListener('scroll', () => {
        const scrollY = window.scrollY;
        const scrolled = scrollY > 60;
        const height = document.documentElement.scrollHeight - window.innerHeight;

        if (navbar) navbar.classList.toggle('scrolled', scrolled);
        if (logo) logo.classList.toggle('compact', scrolled);
        if (backToTop) backToTop.classList.toggle('show', scrollY > 300);
        if (progressBar) progressBar.style.width = ((scrollY / height) * 100) + '%';
    }, { passive: true });

    if (backToTop) {
        backToTop.addEventListener('click', () => window.scrollTo({ top: 0, behavior: 'smooth' }));
    }

    // ═══ PARALLAX على الـ orbs ═══
    const orbs = document.querySelectorAll('.bg-orb');
    if (orbs.length) {
        window.addEventListener('scroll', () => {
            orbs.forEach((orb, i) => {
                orb.style.transform = `translateY(${window.scrollY * (i + 1) * 0.07}px)`;
            });
        }, { passive: true });
    }

    // ═══ CARD TILT (Mouse Tracking) ═══
    document.querySelectorAll('.service-card-v2, .stats-card-v2, .testimonial-card-v3, .video-card-v3').forEach(card => {
        card.addEventListener('mousemove', e => {
            const rect = card.getBoundingClientRect();
            const x = (e.clientX - rect.left) / rect.width - 0.5;
            const y = (e.clientY - rect.top) / rect.height - 0.5;
            card.style.transform = `perspective(800px) rotateY(${x * 6}deg) rotateX(${-y * 6}deg) translateY(-8px) scale(1.02)`;
        });
        card.addEventListener('mouseleave', () => { card.style.transform = ''; });
    });

    // ═══ RIPPLE على الأزرار ═══
    document.querySelectorAll('.btn-primary-v3, .btn-submit-v3, .btn-ghost-v3, .footer-newsletter-btn, .btn, .ripple').forEach(btn => {
        btn.addEventListener('click', function (e) {
            const rect = this.getBoundingClientRect();
            const ripple = document.createElement('span');
            ripple.className = 'ripple-effect';
            ripple.style.left = (e.clientX - rect.left) + 'px';
            ripple.style.top = (e.clientY - rect.top) + 'px';
            this.style.position = 'relative';
            this.style.overflow = 'hidden';
            this.appendChild(ripple);
            setTimeout(() => ripple.remove(), 650);
        });
    });

    // ═══ SMOOTH SCROLL ═══
    document.querySelectorAll('a[href^="#"]').forEach(link => {
        link.addEventListener('click', e => {
            const id = link.getAttribute('href');
            if (id === '#') return;
            const target = document.querySelector(id);
            if (!target) return;
            e.preventDefault();
            target.scrollIntoView({ behavior: 'smooth', block: 'start' });
            const offcanvas = document.querySelector('.offcanvas.show');
            if (offcanvas) {
                const bs = bootstrap.Offcanvas.getInstance(offcanvas);
                if (bs) bs.hide();
            }
        });
    });

    // ═══ GALLERY HOVER OVERLAY ═══
    document.querySelectorAll('.gallery-hover-overlay').forEach(overlay => {
        const card = overlay.closest('[onclick]');
        if (!card) return;
        card.addEventListener('mouseenter', () => overlay.style.opacity = '1');
        card.addEventListener('mouseleave', () => overlay.style.opacity = '0');
    });

    // ═══ GALLERY FILTER ═══
    document.querySelectorAll('.filter-btn').forEach(btn => {
        btn.addEventListener('click', function () {
            document.querySelectorAll('.filter-btn').forEach(b => {
                b.classList.remove('active', 'btn-info', 'text-white');
                b.classList.add('btn-white', 'text-muted');
            });
            this.classList.add('active', 'btn-info', 'text-white');
            this.classList.remove('btn-white', 'text-muted');
            const filter = this.dataset.filter;
            document.querySelectorAll('[data-filter]').forEach(item => {
                const show = filter === 'all' || item.dataset.filter === filter;
                if (show) {
                    item.style.opacity = '1'; item.style.transform = 'scale(1)'; item.style.display = '';
                } else {
                    item.style.opacity = '0'; item.style.transform = 'scale(0.9)';
                    setTimeout(() => { item.style.display = 'none'; }, 300);
                }
            });
        });
    });

    // ═══ VIDEO MODAL ═══
    window.openVideoModal = function (url, title) {
        if (!url || url === '#') return;
        let embedUrl = url;
        const m = url.match(/(?:youtube\.com\/watch\?v=|youtu\.be\/)([^&?\s]+)/);
        if (m) embedUrl = 'https://www.youtube.com/embed/' + m[1] + '?autoplay=1';
        document.getElementById('videoModalFrame').src = embedUrl;
        document.getElementById('videoModalTitle').innerText = title || '';
        document.getElementById('videoModal').style.display = 'flex';
        document.body.style.overflow = 'hidden';
    };
    window.closeVideoModal = function () {
        document.getElementById('videoModal').style.display = 'none';
        document.getElementById('videoModalFrame').src = '';
        document.body.style.overflow = '';
    };

    // ═══ LIGHTBOX ═══
    window.openLightbox = function (imgUrl, title) {
        if (!imgUrl) return;
        document.getElementById('lightboxImg').src = imgUrl;
        document.getElementById('lightboxCaption').innerText = title || '';
        document.getElementById('lightboxModal').style.display = 'flex';
        document.body.style.overflow = 'hidden';
    };
    window.closeLightbox = function () {
        document.getElementById('lightboxModal').style.display = 'none';
        document.body.style.overflow = '';
    };

    document.addEventListener('keydown', e => {
        if (e.key === 'Escape') { closeVideoModal(); closeLightbox(); }
    });

});
AOS.init({
    duration: 800,
    once: true,
    disable: false,
    startEvent: 'DOMContentLoaded',
    offset: 0  // ← ده المهم، يخليه يشتغل من غير ما ينتظر scroll
});