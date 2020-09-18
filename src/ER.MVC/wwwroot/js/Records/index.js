$(document).ready(function () {
    $('#records').DataTable({
        "info": false,
        "language": {
            "lengthMenu": "Mostrando _MENU_ registros por página",
            "zeroRecords": "Nenhum registro encontrado.",
            "info": "Mostando página _PAGE_ de _PAGES_",
            "infoEmpty": "Nenhum registro disponível",
            "search": "Buscar:",
            "paginate": {
                "first": "Primeiro",
                "last": "Último",
                "next": "Próximo",
                "previous": "Anterior"
            }
        },
        "order": [[2, "desc"]]
    });
});