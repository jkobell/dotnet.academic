<!--/********************
Author: James Kobell
Date Created: 04/14/2019
Description: This is ENTD464_Assignment_WK6
Code Behind: Index.aspx.cs
Database: Halloween.mdf - Mike Murach & Associates, Inc - www.murach.com - modified
********************/-->
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title>ENTD464 || Week 6</title>
    <link rel="stylesheet" type="text/css" href="Content/StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrap1">
            <h1>DATABASE MAINTENANCE</h1>          
                <br />
                <div id="txtRow1">  
                    <table id="tbl1">  <%--table to format form textboxes and labels incuding validation messages--%>
                        <tr>
                            <td class="td1">
                                <asp:RequiredFieldValidator CssClass="val" ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="Product ID required."></asp:RequiredFieldValidator>
                                <br />
                                <asp:RegularExpressionValidator CssClass="val" ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="20 Characters Only." ValidationExpression="^[\s\S]{1,20}$"></asp:RegularExpressionValidator>
                                <br />
                                <asp:Label CssClass="lblRow1" ID="Label3" runat="server" Text="Product ID" Font-Bold="True" Font-Names="Segoe UI" align="center"></asp:Label>
                                <br />
                                <asp:TextBox CssClass="txtRow1" ID="TextBox2" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td class="td1">
                                <asp:RequiredFieldValidator CssClass="val"  ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox3" ErrorMessage="Name required."></asp:RequiredFieldValidator>
                                <br />
                                <asp:RegularExpressionValidator CssClass="val" ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox3" ErrorMessage="30 Characters Only." ValidationExpression="^[\s\S]{1,30}$"></asp:RegularExpressionValidator>
                                <br />
                                <asp:Label CssClass="lblRow1" ID="Label4" runat="server" Text="Name" Font-Bold="True" Font-Names="Segoe UI"></asp:Label>
                                <br />
                                <asp:TextBox CssClass="txtRow1" ID="TextBox3" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td class="td1">
                                <asp:RequiredFieldValidator CssClass="val"  ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox4" ErrorMessage="Description required."></asp:RequiredFieldValidator>
                                <br />
                                <asp:RegularExpressionValidator CssClass="val" ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBox4" ErrorMessage="50 Characters Only." ValidationExpression="^[\s\S]{1,50}$"></asp:RegularExpressionValidator>
                                <br />
                                <asp:Label CssClass="lblRow1" ID="Label5" runat="server" Text="Short Desciption" Font-Bold="True" Font-Names="Segoe UI"></asp:Label>
                                <br />
                                <asp:TextBox CssClass="txtRow1" ID="TextBox4" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td class="td1">
                                <asp:RequiredFieldValidator CssClass="val"  ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox5" ErrorMessage="Unit Price required."></asp:RequiredFieldValidator>
                                <br />
                                <asp:RegularExpressionValidator CssClass="val" ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBox5" ErrorMessage="20 Characters Only." ValidationExpression="^[\s\S]{1,20}$"></asp:RegularExpressionValidator>
                                <br />
                                <asp:Label CssClass="lblRow1" ID="Label6" runat="server" Text="Unit Price" Font-Bold="True" Font-Names="Segoe UI"></asp:Label>
                                <br />
                                <asp:TextBox CssClass="txtRow1" ID="TextBox5" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td class="td1">
                                <asp:RequiredFieldValidator CssClass="val" ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox6" ErrorMessage="On Hand Quantity required."></asp:RequiredFieldValidator>
                                <br />
                                <asp:RegularExpressionValidator CssClass="val" ID="RegularExpressionValidator5" runat="server" ControlToValidate="TextBox6" ErrorMessage="20 Characters Only." ValidationExpression="^[\s\S]{1,20}$"></asp:RegularExpressionValidator>
                                <br />
                                <asp:Label CssClass="lblRow1" ID="Label7" runat="server" Text="On Hand" Font-Bold="True" Font-Names="Segoe UI"></asp:Label>
                                <br />
                                <asp:TextBox CssClass="txtRow1" ID="TextBox6" runat="server" Width="200px"></asp:TextBox>
                            </td>
                          </tr>
                        </table>
                    <table id="tbl2">   <%--table to hold buttons--%>
                        <tr>
                            <td class="td1">
                                <asp:Button CssClass="btnRow1" ID="Button3" runat="server" Text="Update" OnClick="Button3_Click" />
                            </td>
                            <td class="td1">
                                <asp:Button CssClass="btnRow1" ID="Button4" runat="server" Text="Insert" OnClick="Button4_Click" />
                            </td>
                            <td class="td1">
                                <asp:Button CssClass="btnRow1" ID="Button5" runat="server" Text="Delete" OnClick="Button5_Click" />
                            </td>
                        </tr>
                  </table>
                </div>            
                <br />
                <br />
                <br />
                <br />               
               <p>
                   <%--hidden label for code-behind error messages--%>
                <asp:Label ID="Label9" runat="server" Text="" Font-Names="Segoe UI" Font-Size="Large" CssClass="Label9"></asp:Label>
               </p>                    
                 <br />               
                <div id="gv1"> <%--GridView to display db table only--%>
                <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" BackColor="#CCFFFF" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" DataKeyNames="ProductID" Height="301px">
                    <Columns>
                        <asp:BoundField DataField="ProductID" HeaderText="ProductID" SortExpression="ProductID" ReadOnly="True" />
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="ShortDescription" HeaderText="ShortDescription" SortExpression="ShortDescription" />
                        <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice" />
                        <asp:BoundField DataField="OnHand" HeaderText="OnHand" SortExpression="OnHand" />
                    </Columns>                   
                </asp:GridView>
                </div>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1 %>" SelectCommand="SELECT * FROM [Products]" OldValuesParameterFormatString="original_{0}">
                </asp:SqlDataSource>

                <div id="drop">
                    <table id="tbl3">
                        <tr id="tr3">
                            <td> <%--DropDown/Select list of primary key column of db table--%>
                                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="ProductID" DataValueField="ProductID"
                                OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AppendDataBoundItems="True" >
                                <asp:ListItem Value="Select" Text="Select"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="Label8" runat="server" Font-Names="Segoe UI" Font-Size="Large" Text="Select a <b>ProductID</b> to edit."></asp:Label>
                            </td>
                       </tr>
                   </table>
               </div>
                <br />
                <br />
        </div>        
    </form>
</body>
</html>
