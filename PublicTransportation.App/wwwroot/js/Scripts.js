function SweetAlert(Data) {
    console.log(Data);
    Swal.fire({
        title: Data.title,
        html: Data.message,
        icon: Data.icon,
        confirmButtonText: 'Close'
    });
}

function SweetAlertWithConfirm(Data) {
    let response = Swal.fire({
        title: Data.title,
        html: Data.message,
        icon: Data.icon,
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: Data.btn_confirm_text,
        cancelButtonText: Data.btn_cancel_text
    }).then((result) => {
        if (result.isConfirmed) {
            return true;
        } else {
            return false;
        }
    });
    return response;
}