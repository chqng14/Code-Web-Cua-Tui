// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function showErrorMessage(message) {
    if (!message) return;

    // Hiển thị thông báo lỗi
    var errorDiv = document.createElement("div");
    errorDiv.classList.add("alert", "alert-danger");
    errorDiv.textContent = message;
    document.body.appendChild(errorDiv);
}

function handleLogin() {
    // Xử lý đăng nhập

    if (data.Count() > 0) {
        //add Session
        HttpContext.Session.SetString("acc", data.FirstOrDefault().UserName);
        return RedirectToAction("Index", "Home");
    }
    else {
        // Gọi hàm showErrorMessage()
        showErrorMessage("Thông tin đăng nhập không chính xác");
        return RedirectToAction("Login");
    }
}