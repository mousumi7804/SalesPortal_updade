//---------------------------------------------------------------------------

function NoOfDaysCal() {
    debugger;
    var datefrm = document.getElementById('<%=frmdate_txt.ClientID %>').value;
    var dateto = document.getElementById('<%=todate_txt.ClientID %>').value;
    var d = new Date(datefrm);
    var d2 = new Date(dateto);
    var datediff = (d2 - d)
    if (datefrm == "") {
        alert("From Date Cannot Be Blank");
        document.getElementById('<%=todate_txt.ClientID %>').value = null;
    }
    else if (datediff < 0) {
        alert("TO Date Cannot Be Less Than From Date");
        document.getElementById('<%=todate_txt.ClientID %>').value = null;
        document.getElementById('<%=noofdays_txt.ClientID %>').value = null;
    }
    else { NoOfDays(); }

}
//------------------------------------------------------------------------------------------
function CheckValidate() {
    var datefrm = document.getElementById('<%=frmdate_txt.ClientID %>').value;
    var dateto = document.getElementById('<%=todate_txt.ClientID %>').value;
    var d = new Date(datefrm);
    var d2 = new Date(dateto);
    var datediff = (d2 - d);

    if (datediff < 0) {
        alert("TO Date Cannot Be Less Than From Date");
        document.getElementById('<%=frmdate_txt.ClientID %>').value = null;
        document.getElementById('<%=todate_txt.ClientID %>').value = null;
        document.getElementById('<%=noofdays_txt.ClientID %>').value = null;

    }
    if (dateto != "") {
        NoOfDays();
    }


}
//----------------------------------------------------------------------------------------------   
function NoOfDays() {
    var datefrm = document.getElementById('<%=frmdate_txt.ClientID %>').value;
    var dateto = document.getElementById('<%=todate_txt.ClientID %>').value;
    var oneDay = 24 * 60 * 60 * 1000;
    var d = new Date(datefrm);
    var d2 = new Date(dateto);
    var datediff = (d2 - d) / oneDay;
    var noofdays = datediff + 1;
    document.getElementById('<%=noofdays_txt.ClientID %>').value = noofdays;
    // alert(datediff);


}