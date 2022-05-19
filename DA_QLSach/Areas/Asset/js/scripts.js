/*!
    * Start Bootstrap - SB Admin v6.0.1 (https://startbootstrap.com/templates/sb-admin)
    * Copyright 2013-2020 Start Bootstrap
    * Licensed under MIT (https://github.com/StartBootstrap/startbootstrap-sb-admin/blob/master/LICENSE)
    */
(function ($) {
    "use strict";
   
    // Add active state to sidbar nav links
    var path = window.location.href; // because the 'href' property of the DOM element is the absolute path
    $("#layoutSidenav_nav .sb-sidenav a.nav-link").each(function () {
        if (this.href === path) {
            $(this).addClass("active");
        }
    });

    // Toggle the side navigation
    $("#sidebarToggle").on("click", function (e) {
        e.preventDefault();
        $("body").toggleClass("sb-sidenav-toggled");
    });
    $(document).ready(function () {
        $('[data-toggle="tooltip"]').tooltip();
        var actions = $("table td:last-child").html();
        $(".add-new").click(function () {
            $(this).attr("disabled", "disabled");
            var index = $("table tbody tr:last-child").index();
            var row = '<tr>' +
                '<td><input type="text" class="form-control" name="matg" id="matg" placeholder="Nhập mã tác giả"></td>' +
                '<td><input type="text" class="form-control" name="tentg" id="tentg" placeholder="Tên tác giả"></td>' +
                '<td><input type="text" class="form-control" name="linkanh" id="linkanh" value="" placeholder="Ảnh bìa"></td>' +
                '<td><input type="text" class="form-control" name="ngaysinh" id="ngaysinh" value="" placeholder="Ngày sinh"></td>' +
                '<td><input type="text" class="form-control" name="quequan" id="quequan" value="" placeholder="Nhập Quê Quán"></td>' +
                '<td><input type="text" class="form-control" name="tieusu" id="tieusu" value="" placeholder="Nhập tiểu sử"></td>' +
                '<td>' + actions + '</td>' +
                '</tr>';
            $("table").append(row);
            $("table tbody tr").eq(index + 1).find(".add, .edit").toggle();
            $('[data-toggle="tooltip"]').tooltip();
        });
    })(jQuery);
})
//$(function () {
//    $('#AlertBox').removeData('hide');
//    $('#AlertBox').delay(1000).slideUp(500);
    
//});