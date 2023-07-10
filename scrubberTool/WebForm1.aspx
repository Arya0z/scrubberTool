<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="scrubberTool.WebForm1" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="lib/jquery/jquery.min.js"></script>
    <script src="lib/bootstrap/js/bootstrap.min.js"></script>
    <link href="lib/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <style type="text/css">
        #form1 {
            height: 359px;
        }
    </style>
</head>
<body style="height: 359px">
    <form id="form1" runat="server">


        <div class="container-md border shadow-lg rounded-4 bg-light p-4 mt-3">

            <div class=" row  ">
                <div class="col-md-5 ">
                    <asp:Label ID="Label2" runat="server" Font-Size="14pt" Text="New file name"></asp:Label>
                    <asp:TextBox CssClass=" col-md-6 form-control" ID="TextBox2" runat="server" CausesValidation="True"></asp:TextBox>
                </div>
                <div class="col-md-5">
                    <asp:Label ID="Label4" runat="server" Font-Size="14pt" Text="Value"></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>

                </div>
                <asp:Button CssClass="btn btn-primary col-md-2 mt-3 " Style="height: 50px;" ID="Button4" runat="server" OnClick="Button4_Click" Text="Update" ViewStateMode="Enabled" />


                <div class=" col-md-5 mt-3">

                    <asp:Label ID="Label5" runat="server" Font-Size="14pt" Text="Select File Format "></asp:Label>

                    <asp:DropDownList class="btn btn-outline-secondary dropdown-toggle" ID="DropDownList1" runat="server" DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
                      <asp:Button CssClass="btn btn-primary " ID="Button5" runat="server" OnClick="Button5_Click" Text="Add a new Format" ViewStateMode="Enabled" />


                </div>
                <div class="col-md-7  mt-3">
                    <asp:FileUpload CssClass="form-control" ID="FileUpload1" runat="server" Visible="true" />

                </div>


            </div>

            <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/FileFormatData/FileFormat.xml" OnTransforming="XmlDataSource1_Transforming"></asp:XmlDataSource>

            <br />


            <asp:Button CssClass="btn btn-primary col-md-2 mt-3 mx-4 " ID="Button1" runat="server" OnClick="Button1_Click" Text="Upload" />
            <asp:Button CssClass="btn btn-primary col-md-2 mt-3 " ID="Button2" runat="server" OnClick="Button2_Click" Text="Dwonload" Enabled="False" />

            <br />

            <br />

            <asp:GridView ID="GridView1" runat="server" Height="16px" Width="369px" CellPadding="4" ForeColor="#333333" GridLines="None" Style="margin-bottom: 0px">

                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
        </div>

        <%--<div id=" alert1">
            <div class="alert alert-danger mt-3 ms-3 w-25 alert-dismissible fade show" role="alert">
                Feel your all details
             <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
            </div>

        </div>--%>
    </form>
    <script type="text/javascript">
        setTimeout(function () {

            // Closing the alert
            $('#alert').alert('close');
        }, 5000);
    </script>
</body>
</html>
