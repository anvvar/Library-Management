<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="viewbooks.aspx.cs" Inherits="WebApplication2.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
        <script>
            $(document).ready(function () {
                $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
            });
        </script>
    </asp:Content>
   
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
            <div class="row">

                <div class="col-sm-12">
                    <center>
                        <h3>
                        Book Inventory List</h3>
                    </center>
                    <div class="row">
                        <div class="col-sm-12 col-md-12">
                            <asp:Panel class="alert alert-success" role="alert" ID="Panel1" runat="server" Visible="False">
                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                            </asp:Panel>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="card-body">
            
  
                  <div class="row">
                     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:eLibraryDBConnectionString %>" SelectCommand="SELECT * FROM [book_master_tbl]"></asp:SqlDataSource>
                     <div class="col">
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1">
                            <Columns>
                                <asp:BoundField DataField="book_id" HeaderText="book_id" ReadOnly="True" SortExpression="book_id" >
                                

                                <ItemStyle Font-Bold="True" />
                                </asp:BoundField>
                                

                                <asp:TemplateField>
                                    <ItemTemplate>
                                       <div class="continer-fluid">
                                             <div class="row">
                                                 <div class="col-lg-10">
                                                     <div class="row">
                                                         <div class="col-12">
                                                             <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large" Text='<%# Eval("book_name") %>'></asp:Label>
                                                         </div>
                                                     </div>
                                                     <div class="row">
                                                         <div class="col-12">

                                                             author-<asp:Label ID="Label3" runat="server" Text='<%# Eval("author_name") %>' Font-Bold="True" Font-Italic="True"></asp:Label>
                                                             &nbsp;| gener-<asp:Label ID="Label5" runat="server" Text='<%# Eval("gener") %>' Font-Bold="True"></asp:Label>
                                                             &nbsp;|&nbsp;language-<asp:Label ID="Label6" runat="server" Text='<%# Eval("language") %>' Font-Bold="True"></asp:Label>

                                                         </div>
                                                     </div>
                                                     <div class="row">
                                                         <div class="col-12">

                                                             publisher-<asp:Label ID="Label4" runat="server" Text='<%# Eval("publisher_name") %>' Font-Bold="True"></asp:Label>
                                                             &nbsp;| published date-
                                                             <asp:Label ID="Label7" runat="server" Text='<%# Eval("publish_date") %>' Font-Bold="True"></asp:Label>
                                                             &nbsp;|pages-<asp:Label ID="Label8" runat="server" Text='<%# Eval("no_of_pages") %>' Font-Bold="True"></asp:Label>
                                                             &nbsp;| edition -<asp:Label ID="Label9" runat="server" Text='<%# Eval("edition") %>' Font-Bold="True"></asp:Label>

                                                         </div>
                                                     </div>
                                                     <div class="row">
                                                         <div class="col-12">

                                                             cost -
                                                             <asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("book_cost") %>'></asp:Label>
                                                             &nbsp;| actual stock<asp:Label ID="Label11" runat="server" Font-Bold="True" Text='<%# Eval("actual_stock") %>'></asp:Label>
                                                             &nbsp;| Avialable-
                                                             <asp:Label ID="Label12" runat="server" Font-Bold="True" Text='<%# Eval("current_stock") %>'></asp:Label>

                                                         </div>
                                                     </div>
                                                     <div class="row">
                                                         <div class="col-12">

                                                             Description -
                                                             <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Smaller" Text='<%# Eval("book_description") %>'></asp:Label>

                                                         </div>
                                                     </div>
                                                 </div>
                                                 <div class="col-lg-2">
                                                     <asp:Image class="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("book_img_link") %>' />
                                                 </div>
                                             </div>
                                       </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                

                            </Columns>
                        </asp:GridView>
                     </div>
                  </div>
               </div>
                    </div>
                </div>
                <center>
                    <a href="homepage.aspx">
                        << Back to Home</a><span class="clearfix"></span>
                            <br />
                            <center>
            </div>
        </div>
    </asp:Content>
