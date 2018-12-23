import toastr from "toastr";

let toastrOptions = {
    showMethod: 'slideDown',
    positionClass: 'toast-bottom-right'
};

export function showToastrSuccess(message) {
    toastr.options = toastrOptions;
    toastr.success(message);
}

export function showToastrError(message) {
    toastr.options = toastrOptions;
    toastr.error(message);
}

export function showToastrInfo(message) {
    toastr.options = toastrOptions;
    toastr.info(message);
}

export function showToastrWarning(message) {
    toastr.options = toastrOptions;
    toastr.warning(message);
}