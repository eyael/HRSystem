<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewCatagory.aspx.cs" Inherits="CatagoryExercise.NewCatagory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Welcome To Catagory Page</h1>

    <asp:Label ID="catagoryName" runat="server" Text="Enter your Catagory Name"></asp:Label>
    <br />
    <asp:TextBox ID="txt1" runat="server"></asp:TextBox>
     <br />

    <asp:Label ID="Discrbtion" runat="server" Text="Enter your discription"></asp:Label>
    <br />
    <asp:TextBox ID="txt2" runat="server"></asp:TextBox>
     <br />
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" BackColor ="Green" OnClick ="btnSubmit_Click" />

    <div class ="row">

        <div class="col-md-10 col-lg-offset-1">

            <asp:GridView ID="gvCatagory" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                    <asp:BoundField DataField="CategName" HeaderText="CategName" SortExpression="CategName" />
                    <asp:BoundField DataField="Desc" HeaderText="Desc" SortExpression="Desc" />
                </Columns>
            </asp:GridView>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [NewCatagory]"></asp:SqlDataSource>

         

        </div>


    </div>
</asp:Content>
