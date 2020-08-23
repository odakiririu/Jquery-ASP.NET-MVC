var homeConfig = {
    pageSize = 3
};
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
                    alert("Successed");
                }
                else {
                    alert("Update Fail")
                }
            }
        })
    },
    loadData: function () {
        $.ajax({
            url: '/Home/GetData',
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
                    homeController.registerEvent();
                }
            }
        })
    },
    paging: function (totalRecord, callBack) {
        var totalPages = Math.ceil(totalRecord / pageSize);
        $('#pagination').twbsPagination({
            totalPages: 35,
            visiblePages: 7,
            onPageClick: function (event, page) {
                $('#page-content').text('Page ' + page);
            }
        });
    }
}
homeController.init();