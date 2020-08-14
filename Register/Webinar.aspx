<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Webinar.aspx.cs" Inherits="Webinar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">



    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width,height=device-height, initial-scale=1.0" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link href="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css"
        rel="stylesheet" type="text/css" />
    <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js"
        type="text/javascript"></script>
    <%-- <link rel="shortcut icon" href="favicon.ico" type="image/x-icon" /><link rel="icon" href="favicon.ico" type="image/ico" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js" type="text/javascript"></script>
    
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    
    <link rel="shortcut icon" href="favicon.ico" type="image/x-icon" /><link rel="icon" href="favicon.ico" type="image/ico" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />--%>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<link href="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css"
    rel="stylesheet" type="text/css" />
<script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>
<link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
<script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js" type="text/javascript"></script>
    <meta http-equiv="Page-Enter" content="blendTrans(Duration=0)">
    <meta http-equiv="Page-Exit" content="blendTrans(Duration=0)">
    <style type="text/css">
        .btn-bs-file
        {
            position: relative;
        }
        .btn-bs-file input[type="file"]
        {
            position: absolute;
            top: -9999999;
            filter: alpha(opacity=0);
            opacity: 0;
            width: 0;
            height: 0;
            outline: none;
            cursor: inherit;
        }
    </style>
    <style type="text/css">
* {
    box-sizing: border-box;
}

<%--input[type=text], select, textarea {
    width: 150px;
    padding: 2px;
    border: 1px solid #ccc;
    border-radius: 2px;
    resize: vertical;
}--%>

label {
    padding: 4px 4px 4px 0;
    display: inline-block;
}

<%--input[type=submit] {
    background-color: #4CAF50;
    color: white;
    
    border: none;
    border-radius: 4px;
    cursor: pointer;
    float: right;
}--%>

input[type=submit]:hover {
    background-color: #45a049;
}

.container {
    
    
    
}

.col-25 {
    float: left;
    width: 10%;
    margin-top: 6px;
        height: 20px;
    }

.col-75 {
    float: left;
    width: 75%;
    margin-top: 6px;
}

/* Clear floats after the columns */
.row:after {
    content: "";
    display: table;
    clear: both;
}

/* Responsive layout - when the screen is less than 600px wide, make the two columns stack on top of each other instead of next to each other */
@media screen and (max-width: 600px) {
    .col-25, .col-75, input[type=submit] {
        width: 100%;
        margin-top: 0;
    }
}
</style>
    <script type="text/javascript">


        function setClipBoardData() {
            setInterval("window.clipboardData.setData('text','')", 20);
        }
        function blockError() {
            window.location.reload(true);
            return true;
        }


        document.write('<style type="text/css">body{display:none}</style>');
        jQuery(function ($) {
            $('body').css('display', 'block');
        });


        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#blah')
                        .attr('src', e.target.result)
                        .width(150)
                        .height(200);
                };

                reader.readAsDataURL(input.files[0]);
            }
        }</script>
    <script type="text/javascript">
        $(function () {
            blinkeffect('#txtblnk');
        })
        function blinkeffect(selector) {
            $(selector).fadeOut('slow', function () {
                $(this).fadeIn('slow', function () {
                    blinkeffect(this);
                });
            });
        }
    </script>
    <script type="text/javascript">
        $(function () {
            blinkeffect1('#txtblnk1');
        })
        function blinkeffect1(selector) {
            $(selector).fadeOut('slow', function () {
                $(this).fadeIn('slow', function () {
                    blinkeffect1(this);
                });
            });
        }
    </script>
    <style type="text/css">
        article, aside, figure, footer, header, hgroup, menu, nav, section
        {
            display: block;
        }
    </style>



    <style scoped="">
        .button-success,
        .button-error,
        .button-warning,
        .button-secondary {
            color: white;
            border-radius: 4px;
            text-shadow: 0 1px 1px rgba(0, 0, 0, 0.2);
        }

        .button-success {
            background: rgb(28, 184, 65);
            /* this is a green */
        }

        .button-error {
            background: rgb(202, 60, 60);
            /* this is a maroon */
        }

        .button-warning {
            background: rgb(223, 117, 20);
            /* this is an orange */
        }

        .button-secondary {
            background: rgb(66, 184, 221);
            /* this is a light blue */
        }




    </style>

    <style scoped="">
        .button-success,
        .button-error,
        .button-warning,
        .button-secondary {
            color: white;
            border-radius: 4px;
            text-shadow: 0 1px 1px rgba(0, 0, 0, 0.2);
        }

        .button-success {
            background: rgb(28, 184, 65);
            /* this is a green */
        }

        .button-error {
            background: rgb(202, 60, 60);
            /* this is a maroon */
        }

        .button-warning {
            background: rgb(223, 117, 20);
            /* this is an orange */
        }

        .button-secondary {
            background: rgb(66, 184, 221);
            /* this is a light blue */
        }




    </style>

    <title>Registration Form</title>  
    
  
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript" src="http://cdn.jsdelivr.net/json2/0.1/json2.js"></script>
    
    <script type="text/javascript">

        $(document).ready(function () {
            $(function () {
                $("[id*=Button1]").bind("click", function () {


                    var summary = "";
                    summary += isvaliduser();
                    summary += isvalidFirstname();
                    summary += isvalidLocation();
                    summary += isvalidSpl();
                    summary += isvalidLastname();
                    summary += isvalidemail();
                    var ch = isvalidemaildef();
                    if (ch == false) {
                        alert("Please enter valid Email ID");
                        return false;
                    }

                    if (summary != "") {
                        alert(summary);
                        return false;
                    }
                   
                        


                    else {
                        

                        var fname = $("[id*=txtfname]").val();

                        var lname = $("[id*=txtlname]").val();
                        var email = $("[id*=txtemail]").val();
                        var place = $("[id*=txtplace]").val();

                        var spl = $("[id*=txtspl]").val();

                       // alert(spl);

                        $.ajax({

                            type: "POST",
                            url: '<%=ResolveUrl("Webinar.aspx/save_rec")%>',
                            data: "{'fname': " + JSON.stringify(fname) + " , 'lname' :" + JSON.stringify(lname) + " , 'email':" + JSON.stringify(email) + ", 'place' : " + JSON.stringify(place) + ", 'spl' : " + JSON.stringify(spl) + " }",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",

                            success: function (result) {
                                //Successfully gone to the server and returned with the string result of the server side function do what you want with the result
                                if (result.d == "true") {
                                    alert("Thanks for registering! We have sent an email to you with some details on getting into the webinar. ");
                                    //$.MessageBox("A plain MessageBox can replace Javascript's window.alert(), and it looks definitely better...");
                                    document.getElementById("<%=txtfname.ClientID%>").value = "";

                                    document.getElementById("<%=txtlname.ClientID%>").value = "";
                                    document.getElementById("<%=txtemail.ClientID%>").value = "";
                                    document.getElementById("<%=txtspl.ClientID%>").value = "";
                                    document.getElementById("<%=txtplace.ClientID%>").value = "";
                                }
                                else {
                                    alert(result.d);
                                }
                            }
                            , error(er) {
                                alert('failure');
                                //Faild to go to the server alert(er.responseText)
                            }
                        });

                    }     return false;
                });
            });


            function isvaliduser() {
                var temp = $("#txtuser").val();
                if (temp == "") {
                    return ("Please Enter UserName" + "\n");
                }
                else {
                    return "";
                }
            }
            function isvalidFirstname() {
                var temp = $("#txtfname").val();
                if (temp == "") {
                    return ("Please Enter firstname" + "\n");
                }
                else {
                    return "";
                }
            }

            function isvalidLastname() {
                var temp = $("#txtlname").val();
                if (temp == "") {
                    return ("Please Enter Lasttname" + "\n");
                }
                else {
                    return "";
                }
            }

            function isvalidLocation() {
                var temp = $("#txtplace").val();
                if (temp == "") {
                    return ("Please Enter Place" + "\n");
                }
                else {
                    return "";
                }
            }


            function isvalidSpl() {
                var temp = $("#txtspl").val();
                if (temp == "") {
                    return ("Please Enter Specialization" + "\n");
                }
                else {
                    return "";
                }
            }

            function isvalidemail() {
                var temp = $("#txtemail").val();
                var ch=""
                if (temp == "") {
                    ch = "Please Enter Email" + "\n"
                    return (ch);
                }
                else {

                    
                    return "";

                }
            }

            function isvalidemaildef() {
                   var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                var ch = regex.test($("#txtemail").val());

                //alert(ch);
                if (ch == false) {
                    return false;
                }
                else {
                    return true;
                }
                
            }




        });
    </script>
   
    <style>
    .container {
        width: 80%;
        margin: 0 auto;
        padding: 20px;
        background: #f0e68c;
    }

     .cont {
        width: 80%;
        margin: 0 auto;
        padding: 20px;
        background: white;
    }


     
        .header img {
  float: left;
  width: 262px;
  height: 138px;
  background: #555;
}

.header h1 {
  position: relative;
  top: 18px;
  left: 10px;
}
</style>
</head>
<body>
    
        <div class="header">
  <img src="../Image/logo_r.jpg"  alt="logo" />
  

    <h5 style="box-sizing: inherit; color: rgb(68, 68, 68); font-weight: normal; font-family: Arvo, &quot;Helvetica Neue&quot;, Helvetica, Arial, sans-serif; line-height: 1.2; margin: 0px 0px 20px; padding: 0px; font-size: 20px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;">&nbsp;</h5>
            <h5 style="box-sizing: inherit; color: rgb(68, 68, 68); font-weight: normal; font-family: Arvo, &quot;Helvetica Neue&quot;, Helvetica, Arial, sans-serif; line-height: 1.2; margin: 0px 0px 20px; padding: 0px; font-size: 20px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;">&nbsp;</h5>
            <h5 style="box-sizing: inherit; color: rgb(68, 68, 68); font-weight: normal; font-family: Arvo, &quot;Helvetica Neue&quot;, Helvetica, Arial, sans-serif; line-height: 1.2; margin: 0px 0px 20px; padding: 0px; font-size: 20px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;">&nbsp;&nbsp;&nbsp;&nbsp; </h5>
            <h5 style="box-sizing: inherit; color: rgb(68, 68, 68); font-weight: normal; font-family: Arvo, &quot;Helvetica Neue&quot;, Helvetica, Arial, sans-serif; line-height: 1.2; margin: 0px 0px 20px; padding: 0px; font-size: 20px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;">&nbsp;</h5>
            </div>

       

    <div class="container">
        <h5 style="box-sizing: inherit; color: rgb(68, 68, 68); font-weight: normal; font-family: Arvo, &quot;Helvetica Neue&quot;, Helvetica, Arial, sans-serif; line-height: 1.2; margin: 0px 0px 20px; padding: 0px; font-size: 20px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;">Webinar Registration Form</h5>
  <div class="cont">
    
        <form  runat="server"  class="wpforms-validate wpforms-form" autocomplete="off" >
            <div class="wpforms-field-container" style="box-sizing: border-box; background: none; border: 0px none; border-radius: 0px; float: none; font-size: 16px; height: auto; letter-spacing: normal; list-style: none; outline: none; position: static; text-decoration: none; text-indent: 0px; text-shadow: none; text-transform: none; width: auto; visibility: visible; overflow: visible; margin: 0px; padding: 0px; box-shadow: none;">
                <div id="wpforms-264009-field_1-container" class="wpforms-field wpforms-field-name" data-field-id="1" style="box-sizing: border-box; background: none; border: 0px none; border-radius: 0px; float: none; font-size: 16px; height: auto; letter-spacing: normal; list-style: none; outline: none; position: static; text-decoration: none; text-indent: 0px; text-shadow: none; text-transform: none; width: auto; visibility: visible; overflow: visible; margin: 0px; padding: 10px 0px; box-shadow: none; clear: both;">
                    <label class="wpforms-field-label" for="wpforms-264009-field_1" style="box-sizing: border-box; background: none; border: 0px; border-radius: 0px; float: none; font-size: 16px; height: auto; letter-spacing: normal; list-style: none; outline: none; position: static; text-decoration: none; text-indent: 0px; text-shadow: none; text-transform: none; width: auto; visibility: visible; overflow: visible; margin: 0px 0px 4px; padding: 0px; box-shadow: none; display: block; vertical-align: middle; font-weight: 700; line-height: 1.3;">
                    Name<span>&nbsp;</span><span class="wpforms-required-label" style="box-sizing: border-box; background: none; border: 0px none; border-radius: 0px; float: none; font-size: 16px; height: auto; letter-spacing: normal; list-style: none; outline: none; position: static; text-decoration: none; text-indent: 0px; text-shadow: none; text-transform: none; width: auto; visibility: visible; overflow: visible; margin: 0px; padding: 0px; box-shadow: none; color: rgb(255, 0, 0); font-weight: 400;">*</span></label><div class="wpforms-field-row wpforms-field-medium" style="box-sizing: border-box; background: none; border: 0px none; border-radius: 0px; float: none; font-size: 16px; height: auto; letter-spacing: normal; list-style: none; outline: none; position: relative; text-decoration: none; text-indent: 0px; text-shadow: none; text-transform: none; width: auto; visibility: visible; overflow: visible; margin: 0px; padding: 0px; box-shadow: none; max-width: 60%;">
                        <div class="wpforms-field-row-block wpforms-first wpforms-one-half" style="box-sizing: border-box; background: none; border: 0px none; border-radius: 0px; float: left; font-size: 16px; height: auto; letter-spacing: normal; list-style: none; outline: none; position: static; text-decoration: none; text-indent: 0px; text-shadow: none; text-transform: none; width: 178.547px; visibility: visible; overflow: visible; margin-top: 0px; margin-right: 0px; margin-bottom: 0px; margin-left: 0px !important; padding: 0px; box-shadow: none; clear: both !important;">

                          <%--  <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>--%>
                            
                            <asp:TextBox ID="txtfname" CssClass="textEntry" Width="320px" AutoCompleteType="Disabled" autocomplete="off" runat="server" class="wpforms-field-name-first wpforms-field-required" name="wpforms[fields][1][first]" required="" style="box-sizing: border-box; font-family: inherit; font-size: 16px; line-height: 1.3; margin: 0px; overflow: visible; background: none rgb(255, 255, 255); border: 1px solid rgb(204, 204, 204); color: rgb(51, 51, 51); padding: 6px 10px; width: 178.547px; border-radius: 2px; float: none; height: 38px; letter-spacing: normal; list-style: none; outline: none; position: static; text-decoration: none; text-indent: 0px; text-shadow: none; text-transform: none; visibility: visible; box-shadow: none; display: block; vertical-align: middle;" type="text" OnTextChanged="txtfname_TextChanged" /><label class="wpforms-field-sublabel after " for="wpforms-264009-field_1" style="box-sizing: border-box; background: none; border: 0px; border-radius: 0px; float: none; font-size: 13px; height: auto; letter-spacing: normal; list-style: none; outline: none; position: static; text-decoration: none; text-indent: 0px; text-shadow: none; text-transform: none; width: auto; visibility: visible; overflow: visible; margin: 4px 0px 0px; padding: 0px; box-shadow: none; display: block; vertical-align: middle; font-weight: 400; line-height: 1.3;"/><label>First</label></div>
                        <div class="wpforms-field-row-block wpforms-one-half" style="box-sizing: border-box; background: none; border: 0px none; border-radius: 0px; float: left; font-size: 16px; height: auto; letter-spacing: normal; list-style: none; outline: none; position: static; text-decoration: none; text-indent: 0px; text-shadow: none; text-transform: none; width: 178.547px; visibility: visible; overflow: visible; margin: 0px 0px 0px 14.875px; padding: 0px; box-shadow: none; clear: none;">
                            <asp:TextBox ID="txtlname"  CssClass="textEntry" Width="320px" AutoCompleteType="Disabled" autocomplete="off" runat="server" class="wpforms-field-name-last wpforms-field-required" name="wpforms[fields][1][last]" required="" style="box-sizing: border-box; font-family: inherit; font-size: 16px; line-height: 1.3; margin: 0px; overflow: visible; background: none rgb(255, 255, 255); border: 1px solid rgb(204, 204, 204); color: rgb(51, 51, 51); padding: 6px 10px; width: 178.547px; border-radius: 2px; float: none; height: 38px; letter-spacing: normal; list-style: none; outline: none; position: static; text-decoration: none; text-indent: 0px; text-shadow: none; text-transform: none; visibility: visible; box-shadow: none; display: block; vertical-align: middle;" type="text" /><label class="wpforms-field-sublabel after " for="wpforms-264009-field_1-last" style="box-sizing: border-box; background: none; border: 0px; border-radius: 0px; float: none; font-size: 13px; height: auto; letter-spacing: normal; list-style: none; outline: none; position: static; text-decoration: none; text-indent: 0px; text-shadow: none; text-transform: none; width: auto; visibility: visible; overflow: visible; margin: 4px 0px 0px; padding: 0px; box-shadow: none; display: block; vertical-align: middle; font-weight: 400; line-height: 1.3;"/><label>Last</label></div>
                    </div>
                </div>
                 <div id="wpforms-264009-field_4-container" class="wpforms-field wpforms-field-email" data-field-id="2" style="box-sizing: border-box; background: none; border: 0px none; border-radius: 0px; float: none; font-size: 16px; height: auto; letter-spacing: normal; list-style: none; outline: none; position: static; text-decoration: none; text-indent: 0px; text-shadow: none; text-transform: none; width: auto; visibility: visible; overflow: visible; margin: 0px; padding: 10px 0px; box-shadow: none; clear: both;">
                    <label class="wpforms-field-label" for="wpforms-264009-field_2" style="box-sizing: border-box; background: none; border: 0px; border-radius: 0px; float: none; font-size: 16px; height: auto; letter-spacing: normal; list-style: none; outline: none; position: static; text-decoration: none; text-indent: 0px; text-shadow: none; text-transform: none; width: auto; visibility: visible; overflow: visible; margin: 0px 0px 4px; padding: 0px; box-shadow: none; display: block; vertical-align: middle; font-weight: 700; line-height: 1.3;">
                   
                        
                        Specialization<span>&nbsp;</span><span class="wpforms-required-label" style="box-sizing: border-box; background: none; border: 0px none; border-radius: 0px; float: none; font-size: 16px; height: auto; letter-spacing: normal; list-style: none; outline: none; position: static; text-decoration: none; text-indent: 0px; text-shadow: none; text-transform: none; width: auto; visibility: visible; overflow: visible; margin: 0px; padding: 0px; box-shadow: none; color: rgb(255, 0, 0); font-weight: 400;">*</span></label><asp:TextBox ID="txtspl" runat="server"  CssClass="textEntry" Width="320px" class="wpforms-field-medium wpforms-field-required" name="wpforms[fields][2]" required="" style="box-sizing: border-box; font-family: inherit; font-size: 16px; line-height: 1.3; margin: 0px; overflow: visible; background: none rgb(255, 255, 255); border: 1px solid rgb(204, 204, 204); color: rgb(51, 51, 51); padding: 6px 10px; width: 372px; border-radius: 2px; float: none; height: 38px; letter-spacing: normal; list-style: none; outline: none; position: static; text-decoration: none; text-indent: 0px; text-shadow: none; text-transform: none; visibility: visible; box-shadow: none; display: block; vertical-align: middle; max-width: 60%;"  /></div>

                <div id="wpforms-264009-field_2-container" class="wpforms-field wpforms-field-email" data-field-id="2" style="box-sizing: border-box; background: none; border: 0px none; border-radius: 0px; float: none; font-size: 16px; height: auto; letter-spacing: normal; list-style: none; outline: none; position: static; text-decoration: none; text-indent: 0px; text-shadow: none; text-transform: none; width: auto; visibility: visible; overflow: visible; margin: 0px; padding: 10px 0px; box-shadow: none; clear: both;">
                    <label class="wpforms-field-label" for="wpforms-264009-field_2" style="box-sizing: border-box; background: none; border: 0px; border-radius: 0px; float: none; font-size: 16px; height: auto; letter-spacing: normal; list-style: none; outline: none; position: static; text-decoration: none; text-indent: 0px; text-shadow: none; text-transform: none; width: auto; visibility: visible; overflow: visible; margin: 0px 0px 4px; padding: 0px; box-shadow: none; display: block; vertical-align: middle; font-weight: 700; line-height: 1.3;">
                   
                        
                        Email<span>&nbsp;</span><span class="wpforms-required-label" style="box-sizing: border-box; background: none; border: 0px none; border-radius: 0px; float: none; font-size: 16px; height: auto; letter-spacing: normal; list-style: none; outline: none; position: static; text-decoration: none; text-indent: 0px; text-shadow: none; text-transform: none; width: auto; visibility: visible; overflow: visible; margin: 0px; padding: 0px; box-shadow: none; color: rgb(255, 0, 0); font-weight: 400;">*</span></label><asp:TextBox ID="txtemail" runat="server" class="wpforms-field-medium wpforms-field-required" name="wpforms[fields][2]" required="" style="box-sizing: border-box; font-family: inherit; font-size: 16px; line-height: 1.3; margin: 0px; overflow: visible; background: none rgb(255, 255, 255); border: 1px solid rgb(204, 204, 204); color: rgb(51, 51, 51); padding: 6px 10px; width: 372px; border-radius: 2px; float: none; height: 38px; letter-spacing: normal; list-style: none; outline: none; position: static; text-decoration: none; text-indent: 0px; text-shadow: none; text-transform: none; visibility: visible; box-shadow: none; display: block; vertical-align: middle; max-width: 60%;" type="email" /></div>
                <div id="wpforms-264009-field_3-container" class="wpforms-field wpforms-field-text" data-field-id="3" style="box-sizing: border-box; background: none; border: 0px none; border-radius: 0px; float: none; font-size: 16px; height: auto; letter-spacing: normal; list-style: none; outline: none; position: static; text-decoration: none; text-indent: 0px; text-shadow: none; text-transform: none; width: auto; visibility: visible; overflow: visible; margin: 0px; padding: 10px 0px; box-shadow: none; clear: both;">
                    <label class="wpforms-field-label" for="wpforms-264009-field_3" style="box-sizing: border-box; background: none; border: 0px; border-radius: 0px; float: none; font-size: 16px; height: auto; letter-spacing: normal; list-style: none; outline: none; position: static; text-decoration: none; text-indent: 0px; text-shadow: none; text-transform: none; width: auto; visibility: visible; overflow: visible; margin: 0px 0px 4px; padding: 0px; box-shadow: none; display: block; vertical-align: middle; font-weight: 700; line-height: 1.3;">
                    Place <span>&nbsp;</span><span class="wpforms-required-label" style="box-sizing: border-box; background: none; border: 0px none; border-radius: 0px; float: none; font-size: 16px; height: auto; letter-spacing: normal; list-style: none; outline: none; position: static; text-decoration: none; text-indent: 0px; text-shadow: none; text-transform: none; width: auto; visibility: visible; overflow: visible; margin: 0px; padding: 0px; box-shadow: none; color: rgb(255, 0, 0); font-weight: 400;">*</span></label> </label>
                    <asp:TextBox ID="txtplace" runat="server" class="wpforms-field-medium" name="wpforms[fields][3]" style="box-sizing: border-box; font-family: inherit; font-size: 16px; line-height: 1.3; margin: 0px; overflow: visible; background: none rgb(255, 255, 255); border: 1px solid rgb(204, 204, 204); color: rgb(51, 51, 51); padding: 6px 10px; width: 372px; border-radius: 2px; float: none; height: 38px; letter-spacing: normal; list-style: none; outline: none; position: static; text-decoration: none; text-indent: 0px; text-shadow: none; text-transform: none; visibility: visible; box-shadow: none; display: block; vertical-align: middle; max-width: 60%;" type="text" /></div>
            </div>
            <div class="wpforms-submit-container" style="box-sizing: border-box; background: none; border: 0px none; border-radius: 0px; float: none; font-size: 16px; height: auto; letter-spacing: normal; list-style: none; outline: none; position: relative; text-decoration: none; text-indent: 0px; text-shadow: none; text-transform: none; width: auto; visibility: visible; overflow: visible; margin: 0px; padding: 10px 0px 0px; box-shadow: none; clear: both;">
                 
               


                    <div>
    

                         <asp:Button ID="Button1" runat="server" Text="Submit" class="button-success pure-button" Height="30px" Width="136px" OnClick="Button1_Click1"   />

                        
    
</div>
                           </div>
        </form>
    
      </div>
     </div>
       
        <p>
            &nbsp;</p>
</body>
</html>
