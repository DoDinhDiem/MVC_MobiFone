// Hàm giải mã token
function decodeJWT(token) {
    const base64Url = token.split('.')[1];
    const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    const jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    return JSON.parse(jsonPayload);
}

// Hàm đăng xuất
function logout() {
    localStorage.removeItem('token');
    window.location.href = '/'; 
}


// Lấy token từ local storage
var token = localStorage.getItem('token');

// Nếu tồn tại token
if (token) {
    // Giải mã token để lấy thông tin người dùng
    var decodedToken = decodeJWT(token);
    var username = decodedToken.unique_name;
    var hoten = decodedToken.HoTen;
    var role = decodedToken.role;

    // Hiển thị thông tin người dùng trên giao diện
    var accountUserNameElement = document.getElementById('username');
    if (accountUserNameElement && username) {
        accountUserNameElement.textContent = username;
    }

    var accountFullNameElement = document.getElementById('fullname');
    if (accountFullNameElement && hoten) {
        accountFullNameElement.textContent = hoten;
    }

    // Kiểm tra và hiển thị các mục trong điều hướng tương ứng với vai trò của người dùng
    if (role === "Role_Admin") {
        var navItems = document.querySelectorAll('.admin-role');
        navItems.forEach(function (item) {
            item.style.display = 'block';
        });
    } else {
        var navItems = document.querySelectorAll('.admin-role');
        navItems.forEach(function (item) {
            item.style.display = 'none';
        });
    }
}
