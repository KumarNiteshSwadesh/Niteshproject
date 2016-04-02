// INIT DATATABLES
$(function () {
	// Init
    var spinner = $( ".spinner" ).spinner();
    var table = $('#table_id').dataTable( {
        "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]], "order": [], "iDisplayLength": 25
    });

    var table = $('#table_id2').dataTable({
        "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]], "order": [], "iDisplayLength": 25
    });

    var table = $('#table_id3').dataTable({
        "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]], "order": [], "iDisplayLength": 10
    });
    //var tableTools = new $.fn.dataTable.TableTools( table, {
    //	"sSwfPath": "../vendors/DataTables/extensions/TableTools/swf/copy_csv_xls_pdf.swf",
    //    "buttons": [
    //        "copy",
    //        "csv",
    //        "xls",
    //        "pdf",
    //        { "type": "print", "buttonText": "Print me!" }
    //    ]
    //} );
    $(".DTTT_container").css("float", "right");
    $(".DTTT_container").css("display", "none");
});


