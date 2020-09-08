var homeConfig = {
    pageSize: 3,
    pageIndex:1 
}
var homeController = {
    init: function () {
        homeController.loadData();            
    },
    registerEvent: function () {
        $('.txtSalary').off('keypress').on('keypress', function (e) {
            if (e.which == 13) {
                var id = $(this).data('id');
                var value = $(this).val();
                homeController.updateSalary(id, value);
            }
        });
        $('#btnAddNew').off('click').on('click', function () {
            $('#modalAddUpdate').modal('show');
            homeController.resetForm();
        });
    }, 
    resetForm: function () {
        $('#hideID').val('0');
        $('#txtName').val('');
        $('#txtSalary').val(0);
        $('#chkStatus').prop('checked',true);
    },
    updateSalary: function (id, value) {
        var data = {
            ID: id,
            Salary: value
        };
        $.ajax({
            url: 'Home/UpdateSalary',
            type: 'POST',
            dataType: 'json',
            data: { model: JSON.stringify(data) },
            success: function (respone) {
                if (respone.status) {
                    alert("Update Salary success!!!");
                }
                else {
                    alert("Update Fail !!!")
                }
            }
        })
    },
    loadData: function () {
        $.ajax({
            url: '/Home/GetData',
            data: {
                page: homeConfig.pageIndex,
                pageSize: homeConfig.pageSize
            },
            type: 'GET',
            dataType: 'json',
            success: function (respone) {
                if (respone.status) {
                    var data = respone.data;
                    var htmlData = '';
                    var template = $('#data-template').html();
                    $.each(data, function (i, item) {
                        htmlData += Mustache.render(template, {
                            ID: item.ID,
                            FullName: item.FullName,
                            Salary: item.Salary,
                            Status: item.Status == true ? "<span class=\"label label-success\">Actived</span>" : "<span class=\"label label-danger\">Lock</span>"
                        });
                    });
                    $('#tblData').html(htmlData);
                    homeController.paging(respone.total, function () {
                        homeController.loadData();
                    });
                    homeController.registerEvent();
                }
            }
        })
    },
    paging: function (totalRecord, callBack) {
        var totalPage = Math.ceil(totalRecord / homeConfig.pageSize);
        $('#pagination').twbsPagination({
            totalPages: totalPage,
            visiblePages: 5,
            onPageClick: function (event, page) {
                homeConfig.pageIndex = page;
                setTimeout(callBack, 200);
            }
        });
    }
}
homeController.init();