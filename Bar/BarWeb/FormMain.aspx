<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormMain.aspx.cs" Inherits="BarWeb.FormMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<style type="text/css">
        #form1 {
            height: 666px;
            width: 1067px;
        }
    </style>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Menu ID="Menu" runat="server" BackColor="White" ForeColor="Black" Height="150px">
            <Items>
                <asp:MenuItem Text="Справочники" Value="Справочники">
                    <asp:MenuItem Text="Завсегдатаи" Value="Завсегдатаи" NavigateUrl="~/FormHabitues.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Ингредиенты" Value="Ингредиенты" NavigateUrl="~/FormIngredients.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Коктейль" Value="Коктейль" NavigateUrl="~/FormCocktails.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Кладовые" Value="Кладовые" NavigateUrl="~/FormPantrys.aspx"></asp:MenuItem>
                     </asp:MenuItem>
                <asp:MenuItem Text="Пополнить кладовую" Value="Пополнить кладовую" NavigateUrl="~/FormPutOnPantry.aspx"></asp:MenuItem>
            </Items>
        </asp:Menu>
        <asp:Button ID="ButtonCreateBooking" runat="server" Text="Создать заказ" OnClick="ButtonCreateBooking_Click" />
        <asp:Button ID="ButtonTakeBookingInWork" runat="server" Text="Отдать на выполнение" OnClick="ButtonTakeBookingInWork_Click" />
        <asp:Button ID="ButtonFinishBooking" runat="server" Text="Заказ готов" OnClick="ButtonFinishBooking_Click" />
        <asp:Button ID="ButtonBookingPayed" runat="server" Text="Заказ оплачен" OnClick="ButtonBookingPayed_Click" />
        <asp:Button ID="ButtonUpd" runat="server" Text="Обновить список" OnClick="ButtonUpd_Click" />
        <asp:GridView ID="dataGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                <asp:CommandField ShowSelectButton="true" SelectText=">>" />
                <asp:BoundField DataField="HabitueFIO" HeaderText="HabitueFIO" SortExpression="HabitueFIO" />
                <asp:BoundField DataField="CocktailName" HeaderText="CocktailName" SortExpression="CocktailName" />
                <asp:BoundField DataField="Count" HeaderText="Count" SortExpression="Count" />
                <asp:BoundField DataField="Sum" HeaderText="Sum" SortExpression="Sum" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                <asp:BoundField DataField="DateCreate" HeaderText="DateCreate" SortExpression="DateCreate" />
                <asp:BoundField DataField="DateImplement" HeaderText="DateImplement" SortExpression="DateImplement" />
            </Columns>
            <SelectedRowStyle BackColor="#CCCCCC" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="BarServiceDAL.BindingModels.BookingBindingModel" DeleteMethod="PayBooking" InsertMethod="CreateBooking" SelectMethod="GetList" TypeName="BarServiceImplement.Implementations.MainServiceList" UpdateMethod="TakeBookingInWork">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>
