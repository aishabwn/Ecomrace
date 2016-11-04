<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Designs.aspx.cs" Inherits="WebApplication3.Customer.Designs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="Srikanth">
    <title>Stitch On Demand</title>
    <!-- Bootstrap Core CSS -->
    <link href="~/css/bootstrap.min.css" rel="stylesheet">
    <!-- Custom CSS -->
    <link href="~/css/the-big-picture.css" rel="stylesheet">
    <link href="~/css/font-icon.css" rel="stylesheet" type="text/css" />
    <link href="~/css/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <link href="~/css/flexslider.css" rel="stylesheet" type="text/css" />
    <link href="~/css/main.css" rel="stylesheet" type="text/css" />
    <link href="~/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="~/css/animate.min.css" rel="stylesheet" type="text/css" />
    <!-- ============ Google fonts ============ -->
    <link href='http://fonts.googleapis.com/css?family=EB+Garamond' rel='stylesheet'
        type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,600,700,300,800'
        rel='stylesheet' type='text/css' />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css">
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->



    <style type="text/css">
        .style1
    {
        width:1322px;
    }
    .style2
    {
        width:552px;
        text-align:left;
    }
    .style3
    {
        width:257px;
        text-align:center
    }
                    
        .style11
        {
            width: 934px;
        }
        .style29
        {
            width: 272px;
        }
            
    </style>
</head>
<body>
    <h3>&nbsp;</h3>
    <form id="form1" runat="server">
    
    <asp:ScriptManager ID="scriptManager1" runat="server"></asp:ScriptManager>
    <div style="background-image: none">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    
    <ContentTemplate>
       
         
          <div id="custom-bootstrap-menu" class="navbar navbar-default navbar-fixed-top" role="navigation">
            <div class="container">
            <div class="navbar-header page-scroll">
                <a class="navbar-brand" href="#">
                   <label style="text-decoration: none; color: #000000; font-size: xx-large; clip: rect(auto, auto, auto, auto); font-family: Impact; font-style: inherit;">
                   <asp:LinkButton ID="LinkButton2" runat="server" Text="Stitch On Demand" Font-Names="" 
                                    Font-Size="20pt" ForeColor="#6600cc" onclick="lblLogo_Click">
                   </asp:LinkButton>
                 
                   </label>
                </a>
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-menubuilder">
                    <span class="sr-only">Toggle navigation</span><span class="icon-bar"></span><span
                        class="icon-bar"></span><span class="icon-bar"></span>
                </button>
            </div>
            <div class="collapse navbar-collapse navbar-menubuilder">
                <ul class="nav navbar-nav navbar-right">
                    <li><a href="../index.aspx">Home</a> </li>
                   
                    
                    <li><a class="page-scroll" href="#intro">About Us</a> </li>
                    <li><a class="page-scroll" href="#contact">Contact Us</a> </li>
                    
                     
                    <li><asp:Image ID="image10" runat="server" Height="53px" ImageUrl="~/img/shop-cart.png" Width="70px" /></li>

                    <li><asp:LinkButton ID="btnShopingHeart" runat="server" Font-Underline="false" 
                                   Font-Size="20pt" ForeColor="Red" onclick="btnShopingHeart_Click1" >0 
                           
                           </asp:LinkButton>
                          
                      </li>
                      
                          
                </ul>
            </div>
        </div>
          </div>
          <table align="center"  class="table">
             
             <tr>
                <td class="style11">
                   <div>
                        <asp:Image ImageUrl="~/img/cover-logo.jpg" runat="server" 
                            Height="300px" Width="1320px" class="img-rounded"/>
                         
                   </div>
                </td>
                 
             </tr>

         
             <tr>
                 <td class="style11">
                    &nbsp;
                 </td>
            </tr>
         
           
             <tr>
                <td>
                    <table align="center" class="style1" style="border:thin ridge #9900FF">
                         <tr>
                            <td class="style3">
                               &nbsp;
                               <asp:Label ID="lblCatagoryName" runat="server" Font-Size="15pt" ForeColor="#6600CC" ></asp:Label>
                               &nbsp;&nbsp;
                               
                                  
                     
                             </td>
                           
                          </tr>
             
                    </table>
               </td>
           </tr>
     
             <tr>
                 <td>
                     <table align="center" class="style1">
                           <tr>

                               <td>
                                  <div align="left" style="width: 50px"></div>
                               </td>

                               <td class="style2" valign="top"  >
                                   <asp:Panel ID="pnlProducts" runat="server" ScrollBars="Auto"  BorderColor="White"
                                        BorderStyle="Inset" BorderWidth="1px" Width="1016px" 
                                       CssClass="align:center;" >
                                       &nbsp;<asp:DataList ID="dlProducts" runat="server" RepeatColumns="3" width="683px" 
                                    Font-Bold="false" Font-Italic="false" Font-Overline="false" 
                                    Font-Strikeout="false" Font-Underline="false">
                                    <ItemTemplate>
                      
                                     <div align="left">
                                     <table cellspacing="1" class="style4" style="border:1px ridge #9900FF">
                          
                                          <tr>
                                             <td style="border-bottom-style:ridge; border-width:1px; border-color:#000000" 
                                                 class="style29">
                                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                             <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("Name") %>' Style="font-weight:700;" ></asp:Label>

                                             </td>
                          
                          
                                          </tr>
                                          <tr>
                                              <td class="style29">
                                                   &nbsp;
                                                 <img alt="" src='<%# Eval("ImageUrl") %>' runat="server" id="imgProductPhoto" style="border:ridge 1px black; width:265px; height:233px; margin-left: 0px;"/>
                                              </td>
                                           </tr>
                                          <tr>
                                               <td style="color: #000000" class="style29">
                                                    Price:<asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price") %>' 
                                                    ForeColor="Red"></asp:Label>
                                               <asp:Image ID="ImageStar" runat="server" Visible="false" ImageUrl="~/img/star.png" 
                                                    Width="20px"  />
                                   &nbsp;Stock:<asp:Label ID="lblQty" runat="server" Text='<%# Eval("Quantity") %>'  ForeColor="Red"></asp:Label>
                                               <asp:HiddenField ID="hfProductID" runat="server" Value='<%# Eval("ProductID") %>' />
                                                </td>
                          
                                          </tr>
                                          <tr>
                                              <td class="style29">
                                              <asp:Button ID="btnAddToCart" runat="server" CommandArgument='<%# Eval("ProductID") %>'
                                                   Text="Add To Cart" Width="100%" BorderColor="Black" BorderStyle="Inset" 
                                                   BorderWidth="1px" onclick="btnAddToCart_Click"  CausesValidation="false" 
                                                   Height="32px"/>
                             
                                               </td>
                                           </tr>
                          
                          
                                   </table>
                        
                        
                                     </div>
                      
                                    </ItemTemplate>
                               <ItemStyle Width="33%" />
                                   </asp:DataList>
                    <asp:LinkButton ID="numbering" runat="server">1</asp:LinkButton>
                                   </asp:Panel>
                                   <asp:Panel ID="pnlMyCart" runat="server" Height="500px" ScrollBars="Auto" BorderColor="black" BorderStyle="Inset" BorderWidth="1px" Visible="false">
                                             <table align="center">
                        
                                                   <tr>
                                                       <td align="center">
                                                        <asp:Label ID="lblAvailableStockProducts" runat ="server"  forColor="red" Font-Bold="true"></asp:Label>
                                 
                                                        <asp:DataList ID="delCartProducts" runat="server" RepeatColumns="3" 
                                                              Font-Bold="false" Font-Italic="false" Font-Overline="false" 
                                                              Font-Strikeout="false" Font-Underline="false" Width="551px" 
                                                              onselectedindexchanged="dlCartProducts_SelectedIndexChanged">
                                             <ItemTemplate>
                                                   <div align="left">
                                                   <table cellspacing="1"  style="border:1px ridge #9900FF;text-align:center;width:172px;">
                          
                                                         <tr>
                                                             <td style="border-bottom-style:ridge; border-width:1px; border-color:#000000">
                                                              <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("Name") %>' Style="font-weight:700"></asp:Label>

                                                             </td>
                                                         </tr>
                                                         <tr>
                             <td>
                                 <img alt="" src='<%# Eval("ImageUrl") %>' runat="server" id="imageProductPhoto" style="border:ridge 1px black; width:112px; height:100px;" />
                             
                             </td>
                          
                          
                          </tr>
                                                         <tr>
                          <td>
                              &nbsp;AvailableStock<asp:Label ID="lblAvailableStock" runat="server" ForeColor="Red" Text='<%# Eval("Quantity") %>' ></asp:Label>
                          
                          </td>
                          </tr>
                                                         <tr>
                              <td>

                                  Price:<asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                  &nbsp;X&nbsp;
                                  <asp:TextBox ID="txtProductQuantity" runat="server" Width="10px" Height="10px"
                                      MaxLength="1" AutoPostBack="true" Text='<%# Eval("Quantity") %>' 
                                      ontextchanged="txtChanged"></asp:TextBox>



                              <asp:HiddenField ID="hfProductID" runat="server" Value='<%# Eval("ProductID") %>' />
                              </td>
                          
                          </tr>
                                                         <tr>
                             <td>
                                 <asp:Button ID="btnRemoveFromCart" runat="server" CommandArgument='<%# Eval("ProductID") %>'
                                 Text="RemoveFromCart" Width="100%" BorderColor="Black" BorderStyle="Inset" 
                                     BorderWidth="1px" onclick="btnRemoveFromCart_Click"  CauseValidation ="false"/>
                             
                             </td>
                          
                          
                          </tr>
                          
                                                   </table>
                        
                        
                                                   </div>
                      
                                             </ItemTemplate>
                      
                                                       </asp:DataList>
                                 
                                 
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td align="center">
                                                            &nbsp;
                                
                                                       </td>
                             
                                                   </tr>
                                                   <tr>
                                                       <td align="center">
                                                           &nbsp;
                                
                                                        </td>
                             
                                                   </tr>
                        
                                            </table>
                    
                                   </asp:Panel>
                    
                    
                               </td>
                               
                           </tr>
                           <tr>
                               <td colspan="2">
                                 <asp:Panel ID="pnlEmptyCart" Visible="false" runat="server">
                                  <div style="Text-align:center;">
                                  <br />
                                  <br />
                                  <br />
                                  <br />
                                  <asp:Image ID="Image4" runat="server" 
                                          Width="536px" ImageUrl="~/img/Empty_shopping_cart.jpg"/>
                                  <br />
                                  <br />
                                  <br />
                                  <br />
                                  </div>
                                 
                                 </asp:Panel>   
                                 <asp:Panel ID="pnlOrderPlacedSuccessfully" runat="server" visible="false">
                                      <div style="text-align:center;">
                                      <br />
                                          <asp:Image ID="image5" runat="server"  
                                              Width="500px" ImageUrl="~/img/Happy_order.jpeg" />
                                          <br /><br />
                                          <label>Order Placed Successfully.......</label><br />
                                          <br />
                                          Transactions will be provided on email that you provided....
                                          <br />
                                          <br />
                                          <br />
                                       <asp:Label ID="lblTransactionNO" runat="server" Style="font-weight:700"> </asp:Label>
                                          <br />
                                          <br />
                                          <br />
                                          <a href="" target="_blank">TrackYourTransactionDetailsHere</a>
                                      </div>
                                
                                 
                                 </asp:Panel>
                                
                               </td>
                           
                           </tr>
                           <tr>
                               <td colspan="2" align="center" style="border:thin ridge #9980FF">
                                   &nbsp;&copy:<a href="#abs">abc.com</a>
                                   ||<a href="" target="_blank">AdminPanel</a>||<a href="">../TrackYourOrder.aspx</a>
                               </td>
                    
                           </tr>
                      </table>

                 </td>
             </tr> 
               
               
          </table>
    </ContentTemplate>
    </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
