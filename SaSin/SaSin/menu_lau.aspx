<%@ Page Title="" Language="C#" MasterPageFile="~/usermaster.Master" AutoEventWireup="true" CodeBehind="menu_lau.aspx.cs" Inherits="SaSin.menu_lau" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div id="main_content">
    		            <div class="wap_1200">
            	

<div class="tieude_giua"><div>Menu</div><span></span></div>
<div class="wap_item" style="text-align:left;">

    <div class="wap_box_new">
    
    
        <% foreach (var myItem in lstmonanlau) { %>
        
            <div class="box_news">
            
                <a class="hinh-news" >
            
                    <img src="<%=ResolveUrl(myItem.HinhAnh)%>" >
                </a>      
                <h3 class="mota"><%= myItem.TenMon %></h3>
                <p class="gia">GIÁ: <%= String.Format( "{0:#,##0}",myItem.DonGia) %> VND </p>
                <div class="mota"> <%= myItem.MoTa %></div>  
                <div class="clear"></div>     
            </div><!---END .box_new--> 
            
        <% } %>
    </div>

<div class="clear"></div>
<
</div><!---END .wap_item--> 
            </div>
                    <div class="clear"></div>       
    </div><!---END #main_content-->
</asp:Content>
