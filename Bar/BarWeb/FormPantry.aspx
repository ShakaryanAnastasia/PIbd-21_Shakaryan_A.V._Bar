﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormPantry.aspx.cs" Inherits="BarWeb.FormPantry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Название&nbsp;
        <asp:TextBox ID="textBoxName" runat="server" Width="208px"></asp:TextBox>
            <br />
            <br />
            <asp:GridView ID="dataGridView" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True">
                <Columns>
                    <asp:BoundField DataField="IngredientName" HeaderText="IngredientName" SortExpression="IngredientName" />
                    <asp:BoundField DataField="Count" HeaderText="Count" SortExpression="Count" />
                </Columns>
                <SelectedRowStyle BackColor="#CCCCCC" />
            </asp:GridView>
            <br />
            <br />
            <asp:Button ID="ButtonSave" runat="server" Text="Сохранить" OnClick="ButtonSave_Click" />
            <asp:Button ID="ButtonCancel" runat="server" Text="Отмена" OnClick="ButtonCancel_Click" />
        </div>
    </form>
</body>
</html>
