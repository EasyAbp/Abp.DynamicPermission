$(function () {

    var l = abp.localization.getResource('EasyAbpAbpDynamicPermission');

    var service = easyAbp.abp.dynamicPermission.permissionGrants.permissionGrant;
    var createModal = new abp.ModalManager(abp.appPath + 'Abp/DynamicPermission/PermissionGrants/PermissionGrant/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Abp/DynamicPermission/PermissionGrants/PermissionGrant/EditModal');

    var dataTable = $('#PermissionGrantTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Edit'),
                                visible: abp.auth.isGranted('EasyAbp.Abp.DynamicPermission.PermissionGrant.Manage'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('EasyAbp.Abp.DynamicPermission.PermissionGrant.Manage'),
                                confirmMessage: function (data) {
                                    return l('PermissionGrantDeletionConfirmationMessage', data.record.id);
                                },
                                action: function (data) {
                                    service.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
            {
                title: l('PermissionGrantName'),
                data: "name"
            },
            {
                title: l('PermissionGrantProviderName'),
                data: "providerName"
            },
            {
                title: l('PermissionGrantProviderKey'),
                data: "providerKey"
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewPermissionGrantButton').click(function (e) {
        e.preventDefault();
        createModal.open({ name: name });
    });
});
