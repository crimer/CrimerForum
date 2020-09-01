"use strict";

var editProfileBtn = document.querySelector('#editProfileBtn');
var editProfileForm = document.querySelector('#editProfileForm');
var editProfileFormCancelBtn = document.querySelector('#editProfileFormCancelBtn');
editProfileBtn.addEventListener('click', function () {
    this.classList.toggle('hide');
    editProfileForm.classList.toggle('hide');
});
editProfileFormCancelBtn.addEventListener('click', function (e) {
    e.preventDefault();
    editProfileForm.classList.toggle('hide');
    editProfileBtn.classList.toggle('hide');
});
//# sourceMappingURL=index.js.map
