<%@ Page Title="" Language="C#" MasterPageFile="~/usermaster.Master" AutoEventWireup="true" CodeBehind="userhome.aspx.cs" Inherits="SaSin.userhome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div id="main_content">
    		        		<style type="text/css">
    .item-doitac ul li{list-style-type: none;display: inline-block;}
    .tieude_doitac {
        color: #f1d803;
        font-size: 22px;
        text-align: center;
    }
    .item-img img{opacity: 0.4;}
    .item-img img:hover{opacity: 1;transition: all 0.4s ease}
</style>
<div class="wap_1200">
	<div class="tieude_giua"><div>Món ăn nổi bật</div><span></span></div>
    
    <div class="wap_box_new">
        
        <!--For-->
        <%--<% foreach (var myItem in lstmonan) { %>
            <h1><%= myItem.MaMon %></h1>
            <h1><%= myItem.TenMon %></h1>
            <h1><%= myItem.DonGia %></h1>
            <h1><%= myItem.MoTa %></h1>
            <p>--------------------</p>
        <% } %>--%>
        <% for (int i = 0; i < lstmonan.Count; i++){%>
            <%
                if(i%2==0)
                {%>
                <div class="box_news box_news_2">
                    <a class="hinh-news" >
            
                        <img src="<%=ResolveUrl(lstmonan[i].HinhAnh)%>" alt="Mì Kim Chi Gà">
                    </a>      
                    <h3 class="mota"><%= lstmonan[i].TenMon %></h3>
                    <p class="gia">GIÁ: <%= String.Format( "{0:#,##0}",lstmonan[i].DonGia) %> VND </p>
                    <div class="mota"> <%= lstmonan[i].MoTa %></div>  
                    <div class="clear"></div>         
                </div><!---END .box_new--> 
            <% } 
            else 
            {
            %>
                <div class="box_news ">
                    <a class="hinh-news" >
                
                        <img src="<%=ResolveUrl(lstmonan[i].HinhAnh)%>" alt="Mì Kim Chi Bò Mỹ">
                    </a>      
                    <h3 class="mota"><%= lstmonan[i].TenMon %></h3>
                    <p class="gia">GIÁ: <%= String.Format( "{0:#,##0}",lstmonan[i].DonGia) %> VND </p>
                    <div class="mota"> <%= lstmonan[i].MoTa %></div>  
                    <div class="clear"></div>         
                </div><!---END .box_new--> 
            <% } %>
            

           <%-- <h1><%= lstmonan[i].MaMon %></h1>
            <h1><%= lstmonan[i].TenMon %></h1>
            <h1><%= lstmonan[i].DonGia %></h1>
            <h1><%= lstmonan[i].MoTa %></h1>
            <p>--------------------</p>--%>
           
        <% } %>
        <!--End For-->
    </div>

</div>

                    <div class="clear"></div>       
    </div><!---END #main_content-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
