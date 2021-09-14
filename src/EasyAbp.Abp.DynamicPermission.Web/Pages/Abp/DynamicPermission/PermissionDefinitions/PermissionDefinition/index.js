$(function () {

    var l = abp.localization.getResource('EasyAbpAbpDynamicPermission');

    var service = easyAbp.abp.dynamicPermission.permissionDefinitions.permissionDefinition;
    var createModal = new abp.ModalManager(abp.appPath + 'Abp/DynamicPermission/PermissionDefinitions/PermissionDefinition/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Abp/DynamicPermission/PermissionDefinitions/PermissionDefinition/EditModal');

    var dataTable = $('#PermissionDefinitionTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('EasyAbp.Abp.DynamicPermission.PermissionDefinition.Update'),
                                action: function (data) {
                                    editModal.open({
                                        name: data.record.name
                                    });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('EasyAbp.Abp.DynamicPermission.PermissionDefinition.Delete'),
                                confirmMessage: function (data) {
                                    return l('PermissionDefinitionDeletionConfirmationMessage', data.record.id);
                                },
                                action: function (data) {
                                    service.delete({
                                            name: data.record.name
                                        })
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
                title: l('PermissionDefinitionName'),
                data: "name"
            },
            {
                title: l('PermissionDefinitionDisplayName'),
                data: "displayName"
            },
            {
                title: l('PermissionDefinitionDescription'),
                data: "description"
            },
            {
                title: l('PermissionDefinitionIsPublic'),
                data: "isPublic"
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewPermissionDefinitionButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
