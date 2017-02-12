USE [TaTa]
GO
SET IDENTITY_INSERT [dbo].[Settings] ON 

INSERT [dbo].[Settings] ([Id], [CreatedDate], [CreatedUserId], [Name], [Priority], [Section], [TypeValue], [UpdatedDate], [Value]) VALUES (1, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, N'CompanyName', 0, N'Common', 0, NULL, N'TaTa')
INSERT [dbo].[Settings] ([Id], [CreatedDate], [CreatedUserId], [Name], [Priority], [Section], [TypeValue], [UpdatedDate], [Value]) VALUES (2, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, N'CompanySalesTel', 0, N'Common', 0, NULL, N'+84 (08) 123-45-67')
INSERT [dbo].[Settings] ([Id], [CreatedDate], [CreatedUserId], [Name], [Priority], [Section], [TypeValue], [UpdatedDate], [Value]) VALUES (3, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, N'CompanySupportTel', 0, N'Common', 0, NULL, N'+84 (08) 123-45-67')
INSERT [dbo].[Settings] ([Id], [CreatedDate], [CreatedUserId], [Name], [Priority], [Section], [TypeValue], [UpdatedDate], [Value]) VALUES (4, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, N'CompanyAddress', 0, N'Common', 0, NULL, N'35 Tôn Đức Thắng, phường Bến Nghé, Quận Nhất<br> TP.Hồ Chí Minh')
INSERT [dbo].[Settings] ([Id], [CreatedDate], [CreatedUserId], [Name], [Priority], [Section], [TypeValue], [UpdatedDate], [Value]) VALUES (5, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, N'SiteGoogleAnalytics', 0, N'Common', 0, NULL, N'123')
INSERT [dbo].[Settings] ([Id], [CreatedDate], [CreatedUserId], [Name], [Priority], [Section], [TypeValue], [UpdatedDate], [Value]) VALUES (7, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, N'CompanyFb', 0, N'Common', 7, NULL, N'http://facebook.com')
INSERT [dbo].[Settings] ([Id], [CreatedDate], [CreatedUserId], [Name], [Priority], [Section], [TypeValue], [UpdatedDate], [Value]) VALUES (8, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, N'CompanyYouTube', 0, N'Common', 7, NULL, N'http://youtube.com')
INSERT [dbo].[Settings] ([Id], [CreatedDate], [CreatedUserId], [Name], [Priority], [Section], [TypeValue], [UpdatedDate], [Value]) VALUES (9, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, N'CompanyTweet', 0, N'Common', 7, NULL, N'http://twitter.com')
INSERT [dbo].[Settings] ([Id], [CreatedDate], [CreatedUserId], [Name], [Priority], [Section], [TypeValue], [UpdatedDate], [Value]) VALUES (10, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, N'CompanyLinkedin', 0, N'Common', 7, NULL, N'http://linkedin.com')
INSERT [dbo].[Settings] ([Id], [CreatedDate], [CreatedUserId], [Name], [Priority], [Section], [TypeValue], [UpdatedDate], [Value]) VALUES (11, CAST(N'2017-02-09T00:00:00.0000000' AS DateTime2), NULL, N'AboutExcert', 0, N'About', 2, NULL, N'<h5>Lĩnh vực hoạt động</h5>
      <p>
        TaTa là một công ty hoạt động trong nhiều lĩnh vực CNTT: trung tâm dữ liệu, nhà đăng ký tên miền Quốc tế và Việt Nam, cung cấp dịch vụ cho thuê máy chủ, đặt website, phát triển ứng dụng quản lý, cung cấp hạ tầng web, các giải pháp về phát triển website và ứng dụng trên nền web v.v….</p>')
INSERT [dbo].[Settings] ([Id], [CreatedDate], [CreatedUserId], [Name], [Priority], [Section], [TypeValue], [UpdatedDate], [Value]) VALUES (12, CAST(N'2017-02-09T00:00:00.0000000' AS DateTime2), NULL, N'AboutService', 1, N'About', 2, NULL, N'<div class="panel panel-default panel-bg active">
              <div class="panel-heading">
                <div class="panel-title">
                  <a data-toggle="collapse" data-parent="#accordion" href="#collapse1">
                    VPS (Virtual Private Server)
                  </a>
                </div>
              </div>
              <div id="collapse1" class="panel-collapse collapse in">
                <div class="panel-body">
                  Lorem ipsum dolor sit amet, consectetur adipisicing elit. Quis quas ullam pariatur earum dignissimos consequatur velit nemo libero?
                </div>
              </div>
            </div>')
INSERT [dbo].[Settings] ([Id], [CreatedDate], [CreatedUserId], [Name], [Priority], [Section], [TypeValue], [UpdatedDate], [Value]) VALUES (13, CAST(N'2017-02-09T00:00:00.0000000' AS DateTime2), NULL, N'AboutService', 2, N'About', 2, NULL, N'<div class="panel panel-default panel-bg">
              <div class="panel-heading">
                <div class="panel-title">
                  <a data-toggle="collapse" data-parent="#accordion" href="#collapse2">
                    Domain name
                  </a>
                </div>
              </div>
              <div id="collapse2" class="panel-collapse collapse">
                <div class="panel-body">
                  Lorem ipsum dolor sit amet, consectetur adipisicing elit. Itaque natus quaerat voluptate? Asperiores hic dolore voluptate corporis obcaecati reiciendis sunt ipsam iste. Eligendi inventore voluptatibus quia saepe odit deserunt nam?
                </div>
              </div>
            </div>')
INSERT [dbo].[Settings] ([Id], [CreatedDate], [CreatedUserId], [Name], [Priority], [Section], [TypeValue], [UpdatedDate], [Value]) VALUES (14, CAST(N'2017-02-09T00:00:00.0000000' AS DateTime2), NULL, N'AboutService', 3, N'About', 2, NULL, N'<div class="panel panel-default panel-bg">
              <div class="panel-heading">
                <div class="panel-title">
                  <a data-toggle="collapse" data-parent="#accordion" href="#collapse3">
                    Cloud Hosting
                  </a>
                </div>
              </div>
              <div id="collapse3" class="panel-collapse collapse">
                <div class="panel-body">
                  <img class="replace-2x alignleft" src="content/img/animations.png" width="100" height="62" alt="">
                  Lorem ipsum dolor sit amet, consectetur adipisicing elit. Dolores ipsa esse obcaecati repudiandae veniam amet modi recusandae optio earum sequi accusantium culpa vitae iste sit commodi eaque voluptatem officia quam. Molestiae nobis quidem atque explicabo eum facilis libero porro in fugiat pariatur molestias maiores voluptates rerum ipsa architecto quae assumenda harum fuga modi accusantium nihil dolor consequatur totam commodi quam quas neque dolorem veritatis unde adipisci ad illo excepturi quia facere reprehenderit non alias cum minima labore quo repudiandae perferendis?
                </div>
              </div>
            </div>')
INSERT [dbo].[Settings] ([Id], [CreatedDate], [CreatedUserId], [Name], [Priority], [Section], [TypeValue], [UpdatedDate], [Value]) VALUES (15, CAST(N'2017-02-09T00:00:00.0000000' AS DateTime2), NULL, N'AboutService', 4, N'About', 2, NULL, N'<div class="panel panel-default panel-bg">
              <div class="panel-heading">
                <div class="panel-title">
                  <a data-toggle="collapse" data-parent="#accordion" href="#collapse4">
                    Cloud Server
                  </a>
                </div>
              </div>
              <div id="collapse4" class="panel-collapse collapse">
                <div class="panel-body">
                  <img class="replace-2x alignleft" src="content/img/animations.png" width="100" height="62" alt="">
                  Lorem ipsum dolor sit amet, consectetur adipisicing elit. Dolores ipsa esse obcaecati repudiandae veniam amet modi recusandae optio earum sequi accusantium culpa vitae iste sit commodi eaque voluptatem officia quam. Molestiae nobis quidem atque explicabo eum facilis libero porro in fugiat pariatur molestias maiores voluptates rerum ipsa architecto quae assumenda harum fuga modi accusantium nihil dolor consequatur totam commodi quam quas neque dolorem veritatis unde adipisci ad illo excepturi quia facere reprehenderit non alias cum minima labore quo repudiandae perferendis?
                </div>
              </div>
            </div>')
INSERT [dbo].[Settings] ([Id], [CreatedDate], [CreatedUserId], [Name], [Priority], [Section], [TypeValue], [UpdatedDate], [Value]) VALUES (16, CAST(N'2017-02-09T00:00:00.0000000' AS DateTime2), NULL, N'AboutPartner', 1, N'About', 3, NULL, N'<img class="replace-2x img-rounded" src="~/images/icannnew-h.png" width="170" height="170" alt="">')
INSERT [dbo].[Settings] ([Id], [CreatedDate], [CreatedUserId], [Name], [Priority], [Section], [TypeValue], [UpdatedDate], [Value]) VALUES (17, CAST(N'2017-02-09T00:00:00.0000000' AS DateTime2), NULL, N'AboutPartner', 2, N'About', 3, NULL, N'<img class="replace-2x img-rounded" src="~/images/cpanel-h.png" width="170" height="170" alt="">')
INSERT [dbo].[Settings] ([Id], [CreatedDate], [CreatedUserId], [Name], [Priority], [Section], [TypeValue], [UpdatedDate], [Value]) VALUES (18, CAST(N'2017-02-09T00:00:00.0000000' AS DateTime2), NULL, N'AboutPartner', 3, N'About', 3, NULL, N'<img class="replace-2x img-rounded" src="~/images/parallels-h.png" width="170" height="170" alt="">')
INSERT [dbo].[Settings] ([Id], [CreatedDate], [CreatedUserId], [Name], [Priority], [Section], [TypeValue], [UpdatedDate], [Value]) VALUES (19, CAST(N'2017-02-09T00:00:00.0000000' AS DateTime2), NULL, N'AboutPartner', 4, N'About', 3, NULL, N'<img class="replace-2x img-rounded" src="~/images/ods-h.png" width="170" height="170" alt="">')
INSERT [dbo].[Settings] ([Id], [CreatedDate], [CreatedUserId], [Name], [Priority], [Section], [TypeValue], [UpdatedDate], [Value]) VALUES (20, CAST(N'2017-02-09T00:00:00.0000000' AS DateTime2), NULL, N'AboutPartner', 5, N'About', 3, NULL, N'<img class="replace-2x img-rounded" src="~/images/smartlink-h.png" width="170" height="170" alt="">')
INSERT [dbo].[Settings] ([Id], [CreatedDate], [CreatedUserId], [Name], [Priority], [Section], [TypeValue], [UpdatedDate], [Value]) VALUES (21, CAST(N'2017-02-09T00:00:00.0000000' AS DateTime2), NULL, N'AboutPartner', 6, N'About', 3, NULL, N'<img class="replace-2x img-rounded" src="~/images/cpanel-h.png" width="170" height="170" alt="">')
INSERT [dbo].[Settings] ([Id], [CreatedDate], [CreatedUserId], [Name], [Priority], [Section], [TypeValue], [UpdatedDate], [Value]) VALUES (22, CAST(N'2017-02-09T00:00:00.0000000' AS DateTime2), NULL, N'AboutPartner', 7, N'About', 3, NULL, N'<img class="replace-2x img-rounded" src="~/images/parallels-h.png" width="170" height="170" alt="">')
INSERT [dbo].[Settings] ([Id], [CreatedDate], [CreatedUserId], [Name], [Priority], [Section], [TypeValue], [UpdatedDate], [Value]) VALUES (23, CAST(N'2017-02-12T00:00:00.0000000' AS DateTime2), NULL, N'HomeProductFeature', 0, N'Home', 5, NULL, N'1,2,3,4')
INSERT [dbo].[Settings] ([Id], [CreatedDate], [CreatedUserId], [Name], [Priority], [Section], [TypeValue], [UpdatedDate], [Value]) VALUES (24, CAST(N'2017-02-12T00:00:00.0000000' AS DateTime2), NULL, N'HomeSliderBox', 1, N'Home', 2, NULL, N'<img class="replace-2x" src="~/content/img/home-banner-1.jpeg" width="900" height="450" alt="">')
INSERT [dbo].[Settings] ([Id], [CreatedDate], [CreatedUserId], [Name], [Priority], [Section], [TypeValue], [UpdatedDate], [Value]) VALUES (25, CAST(N'2017-02-12T00:00:00.0000000' AS DateTime2), NULL, N'HomeSliderBox', 2, N'Home', 2, NULL, N'<img class="replace-2x" src="~/content/img/home-banner-2.jpeg" width="900" height="450" alt="">')
INSERT [dbo].[Settings] ([Id], [CreatedDate], [CreatedUserId], [Name], [Priority], [Section], [TypeValue], [UpdatedDate], [Value]) VALUES (26, CAST(N'2017-02-12T00:00:00.0000000' AS DateTime2), NULL, N'HomeSliderBox', 3, N'Home', 2, NULL, N'<img class="replace-2x" src="~/content/img/home-banner-3.jpeg" width="900" height="450" alt="">')
INSERT [dbo].[Settings] ([Id], [CreatedDate], [CreatedUserId], [Name], [Priority], [Section], [TypeValue], [UpdatedDate], [Value]) VALUES (27, CAST(N'2017-02-12T00:00:00.0000000' AS DateTime2), NULL, N'HomeSliderBanner', 1, N'Home', 2, NULL, N'<img class="replace-2x" src="~/content/img/home-banner-11.png" width="270" height="150" alt="">')
INSERT [dbo].[Settings] ([Id], [CreatedDate], [CreatedUserId], [Name], [Priority], [Section], [TypeValue], [UpdatedDate], [Value]) VALUES (28, CAST(N'2017-02-12T00:00:00.0000000' AS DateTime2), NULL, N'HomeSliderBanner', 2, N'Home', 2, NULL, N'<img class="replace-2x" src="~/content/img/home-banner-12.png" width="270" height="150" alt="">')
INSERT [dbo].[Settings] ([Id], [CreatedDate], [CreatedUserId], [Name], [Priority], [Section], [TypeValue], [UpdatedDate], [Value]) VALUES (29, CAST(N'2017-02-12T00:00:00.0000000' AS DateTime2), NULL, N'HomeSliderBanner', 3, N'Home', 2, NULL, N'<img class="replace-2x" src="~/content/img/home-banner-13.png" width="270" height="150" alt="">')
INSERT [dbo].[Settings] ([Id], [CreatedDate], [CreatedUserId], [Name], [Priority], [Section], [TypeValue], [UpdatedDate], [Value]) VALUES (30, CAST(N'2017-02-12T00:00:00.0000000' AS DateTime2), NULL, N'HomeSliderLink', 1, N'Home', 7, NULL, N'#')
INSERT [dbo].[Settings] ([Id], [CreatedDate], [CreatedUserId], [Name], [Priority], [Section], [TypeValue], [UpdatedDate], [Value]) VALUES (31, CAST(N'2017-02-12T00:00:00.0000000' AS DateTime2), NULL, N'HomeSliderLink', 2, N'Home', 7, NULL, N'#')
INSERT [dbo].[Settings] ([Id], [CreatedDate], [CreatedUserId], [Name], [Priority], [Section], [TypeValue], [UpdatedDate], [Value]) VALUES (32, CAST(N'2017-02-12T00:00:00.0000000' AS DateTime2), NULL, N'HomeSliderLink', 2, N'Home', 7, NULL, N'#')
SET IDENTITY_INSERT [dbo].[Settings] OFF
SET IDENTITY_INSERT [dbo].[ProductCategories] ON 

INSERT [dbo].[ProductCategories] ([Id], [CreatedDate], [CreatedUserId], [Description], [Name], [Priority], [UpdatedDate]) VALUES (1, CAST(N'2017-02-04T22:03:45.3070000' AS DateTime2), NULL, N'Virtual Private Server', N'VPS', 1, NULL)
SET IDENTITY_INSERT [dbo].[ProductCategories] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [CreatedDate], [CreatedUserId], [Description], [Name], [Priority], [ProductCategoryId], [UpdatedDate], [MetaTagDescription], [MetaTagKeywords], [MetaTagTitle], [Status], [Quantity]) VALUES (1, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, N'Cloud Server Windows Plan T1', N'VPS Windows T1', 1, 1, NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Products] ([Id], [CreatedDate], [CreatedUserId], [Description], [Name], [Priority], [ProductCategoryId], [UpdatedDate], [MetaTagDescription], [MetaTagKeywords], [MetaTagTitle], [Status], [Quantity]) VALUES (2, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, N'Cloud Server Windows Plan T2', N'VPS Windows T2', 2, 1, NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Products] ([Id], [CreatedDate], [CreatedUserId], [Description], [Name], [Priority], [ProductCategoryId], [UpdatedDate], [MetaTagDescription], [MetaTagKeywords], [MetaTagTitle], [Status], [Quantity]) VALUES (3, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, N'Cloud Server Windows Plan T3', N'VPS Windows T3', 3, 1, NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Products] ([Id], [CreatedDate], [CreatedUserId], [Description], [Name], [Priority], [ProductCategoryId], [UpdatedDate], [MetaTagDescription], [MetaTagKeywords], [MetaTagTitle], [Status], [Quantity]) VALUES (4, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, N'Cloud Server Windows Plan T4', N'VPS Windows T4', 4, 1, NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Products] ([Id], [CreatedDate], [CreatedUserId], [Description], [Name], [Priority], [ProductCategoryId], [UpdatedDate], [MetaTagDescription], [MetaTagKeywords], [MetaTagTitle], [Status], [Quantity]) VALUES (5, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, N'Cloud Server Linux Plan T1', N'VPS Linux T1', 5, 1, NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Products] ([Id], [CreatedDate], [CreatedUserId], [Description], [Name], [Priority], [ProductCategoryId], [UpdatedDate], [MetaTagDescription], [MetaTagKeywords], [MetaTagTitle], [Status], [Quantity]) VALUES (6, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, N'Cloud Server Linux Plan T2', N'VPS Linux T2', 6, 1, NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Products] ([Id], [CreatedDate], [CreatedUserId], [Description], [Name], [Priority], [ProductCategoryId], [UpdatedDate], [MetaTagDescription], [MetaTagKeywords], [MetaTagTitle], [Status], [Quantity]) VALUES (7, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, N'Cloud Server Linux Plan T3', N'VPS Linux T3', 7, 1, NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Products] ([Id], [CreatedDate], [CreatedUserId], [Description], [Name], [Priority], [ProductCategoryId], [UpdatedDate], [MetaTagDescription], [MetaTagKeywords], [MetaTagTitle], [Status], [Quantity]) VALUES (8, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, N'Cloud Server Linux Plan T4', N'VPS Linux T4', 8, 1, NULL, NULL, NULL, NULL, 0, 0)
SET IDENTITY_INSERT [dbo].[Products] OFF
SET IDENTITY_INSERT [dbo].[ProductPrices] ON 

INSERT [dbo].[ProductPrices] ([Id], [CreatedDate], [CreatedUserId], [Currency], [IsDefault], [IsDisabled], [Name], [Price], [Priority], [ProductId], [Unit], [UnitQuantity], [UpdatedDate]) VALUES (2, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 0, 0, N'3 tháng', CAST(700000.00 AS Decimal(18, 2)), 3, 1, N'tháng', 3, NULL)
INSERT [dbo].[ProductPrices] ([Id], [CreatedDate], [CreatedUserId], [Currency], [IsDefault], [IsDisabled], [Name], [Price], [Priority], [ProductId], [Unit], [UnitQuantity], [UpdatedDate]) VALUES (3, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 0, 0, N'6 tháng', CAST(675000.00 AS Decimal(18, 2)), 2, 1, N'tháng', 6, NULL)
INSERT [dbo].[ProductPrices] ([Id], [CreatedDate], [CreatedUserId], [Currency], [IsDefault], [IsDisabled], [Name], [Price], [Priority], [ProductId], [Unit], [UnitQuantity], [UpdatedDate]) VALUES (4, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 1, 0, N'2 tháng', CAST(650000.00 AS Decimal(18, 2)), 1, 1, N'tháng', 12, NULL)
INSERT [dbo].[ProductPrices] ([Id], [CreatedDate], [CreatedUserId], [Currency], [IsDefault], [IsDisabled], [Name], [Price], [Priority], [ProductId], [Unit], [UnitQuantity], [UpdatedDate]) VALUES (5, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 0, 0, N'3 tháng', CAST(1100000.00 AS Decimal(18, 2)), 3, 2, N'tháng', 3, NULL)
INSERT [dbo].[ProductPrices] ([Id], [CreatedDate], [CreatedUserId], [Currency], [IsDefault], [IsDisabled], [Name], [Price], [Priority], [ProductId], [Unit], [UnitQuantity], [UpdatedDate]) VALUES (6, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 0, 0, N'6 tháng', CAST(1050000.00 AS Decimal(18, 2)), 2, 2, N'tháng', 6, NULL)
INSERT [dbo].[ProductPrices] ([Id], [CreatedDate], [CreatedUserId], [Currency], [IsDefault], [IsDisabled], [Name], [Price], [Priority], [ProductId], [Unit], [UnitQuantity], [UpdatedDate]) VALUES (7, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 1, 0, N'12 tháng', CAST(1000000.00 AS Decimal(18, 2)), 1, 2, N'tháng', 12, NULL)
INSERT [dbo].[ProductPrices] ([Id], [CreatedDate], [CreatedUserId], [Currency], [IsDefault], [IsDisabled], [Name], [Price], [Priority], [ProductId], [Unit], [UnitQuantity], [UpdatedDate]) VALUES (8, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 0, 0, N'3 tháng', CAST(1650000.00 AS Decimal(18, 2)), 3, 3, N'tháng', 3, NULL)
INSERT [dbo].[ProductPrices] ([Id], [CreatedDate], [CreatedUserId], [Currency], [IsDefault], [IsDisabled], [Name], [Price], [Priority], [ProductId], [Unit], [UnitQuantity], [UpdatedDate]) VALUES (9, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 0, 0, N'6 tháng', CAST(1540000.00 AS Decimal(18, 2)), 2, 3, N'tháng', 6, NULL)
INSERT [dbo].[ProductPrices] ([Id], [CreatedDate], [CreatedUserId], [Currency], [IsDefault], [IsDisabled], [Name], [Price], [Priority], [ProductId], [Unit], [UnitQuantity], [UpdatedDate]) VALUES (10, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 1, 0, N'12 tháng', CAST(1450000.00 AS Decimal(18, 2)), 1, 3, N'tháng', 12, NULL)
INSERT [dbo].[ProductPrices] ([Id], [CreatedDate], [CreatedUserId], [Currency], [IsDefault], [IsDisabled], [Name], [Price], [Priority], [ProductId], [Unit], [UnitQuantity], [UpdatedDate]) VALUES (11, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 0, 0, N'3 tháng', CAST(2240000.00 AS Decimal(18, 2)), 3, 4, N'tháng', 3, NULL)
INSERT [dbo].[ProductPrices] ([Id], [CreatedDate], [CreatedUserId], [Currency], [IsDefault], [IsDisabled], [Name], [Price], [Priority], [ProductId], [Unit], [UnitQuantity], [UpdatedDate]) VALUES (12, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 0, 0, N'6 tháng', CAST(2140000.00 AS Decimal(18, 2)), 2, 4, N'tháng', 6, NULL)
INSERT [dbo].[ProductPrices] ([Id], [CreatedDate], [CreatedUserId], [Currency], [IsDefault], [IsDisabled], [Name], [Price], [Priority], [ProductId], [Unit], [UnitQuantity], [UpdatedDate]) VALUES (13, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 1, 0, N'12 tháng', CAST(2040000.00 AS Decimal(18, 2)), 1, 4, N'tháng', 12, NULL)
INSERT [dbo].[ProductPrices] ([Id], [CreatedDate], [CreatedUserId], [Currency], [IsDefault], [IsDisabled], [Name], [Price], [Priority], [ProductId], [Unit], [UnitQuantity], [UpdatedDate]) VALUES (14, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 0, 0, N'3 tháng', CAST(700000.00 AS Decimal(18, 2)), 3, 5, N'tháng', 3, NULL)
INSERT [dbo].[ProductPrices] ([Id], [CreatedDate], [CreatedUserId], [Currency], [IsDefault], [IsDisabled], [Name], [Price], [Priority], [ProductId], [Unit], [UnitQuantity], [UpdatedDate]) VALUES (15, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 0, 0, N'6 tháng', CAST(675000.00 AS Decimal(18, 2)), 2, 5, N'tháng', 6, NULL)
INSERT [dbo].[ProductPrices] ([Id], [CreatedDate], [CreatedUserId], [Currency], [IsDefault], [IsDisabled], [Name], [Price], [Priority], [ProductId], [Unit], [UnitQuantity], [UpdatedDate]) VALUES (16, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 1, 0, N'12 tháng', CAST(650000.00 AS Decimal(18, 2)), 1, 5, N'tháng', 12, NULL)
INSERT [dbo].[ProductPrices] ([Id], [CreatedDate], [CreatedUserId], [Currency], [IsDefault], [IsDisabled], [Name], [Price], [Priority], [ProductId], [Unit], [UnitQuantity], [UpdatedDate]) VALUES (17, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 0, 0, N'3 tháng', CAST(1100000.00 AS Decimal(18, 2)), 3, 6, N'tháng', 3, NULL)
INSERT [dbo].[ProductPrices] ([Id], [CreatedDate], [CreatedUserId], [Currency], [IsDefault], [IsDisabled], [Name], [Price], [Priority], [ProductId], [Unit], [UnitQuantity], [UpdatedDate]) VALUES (18, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 0, 0, N'6 tháng', CAST(1050000.00 AS Decimal(18, 2)), 2, 6, N'tháng', 6, NULL)
INSERT [dbo].[ProductPrices] ([Id], [CreatedDate], [CreatedUserId], [Currency], [IsDefault], [IsDisabled], [Name], [Price], [Priority], [ProductId], [Unit], [UnitQuantity], [UpdatedDate]) VALUES (19, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 1, 0, N'12 tháng', CAST(1000000.00 AS Decimal(18, 2)), 1, 6, N'tháng', 12, NULL)
INSERT [dbo].[ProductPrices] ([Id], [CreatedDate], [CreatedUserId], [Currency], [IsDefault], [IsDisabled], [Name], [Price], [Priority], [ProductId], [Unit], [UnitQuantity], [UpdatedDate]) VALUES (20, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 0, 0, N'3 tháng', CAST(1650000.00 AS Decimal(18, 2)), 3, 7, N'tháng', 3, NULL)
INSERT [dbo].[ProductPrices] ([Id], [CreatedDate], [CreatedUserId], [Currency], [IsDefault], [IsDisabled], [Name], [Price], [Priority], [ProductId], [Unit], [UnitQuantity], [UpdatedDate]) VALUES (21, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 0, 0, N'6 tháng', CAST(1540000.00 AS Decimal(18, 2)), 2, 7, N'tháng', 6, NULL)
INSERT [dbo].[ProductPrices] ([Id], [CreatedDate], [CreatedUserId], [Currency], [IsDefault], [IsDisabled], [Name], [Price], [Priority], [ProductId], [Unit], [UnitQuantity], [UpdatedDate]) VALUES (22, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 1, 0, N'12 tháng', CAST(1450000.00 AS Decimal(18, 2)), 1, 7, N'tháng', 12, NULL)
INSERT [dbo].[ProductPrices] ([Id], [CreatedDate], [CreatedUserId], [Currency], [IsDefault], [IsDisabled], [Name], [Price], [Priority], [ProductId], [Unit], [UnitQuantity], [UpdatedDate]) VALUES (23, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 0, 0, N'3 tháng', CAST(2240000.00 AS Decimal(18, 2)), 3, 8, N'tháng', 3, NULL)
INSERT [dbo].[ProductPrices] ([Id], [CreatedDate], [CreatedUserId], [Currency], [IsDefault], [IsDisabled], [Name], [Price], [Priority], [ProductId], [Unit], [UnitQuantity], [UpdatedDate]) VALUES (24, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 0, 0, N'6 tháng', CAST(2140000.00 AS Decimal(18, 2)), 2, 8, N'tháng', 6, NULL)
INSERT [dbo].[ProductPrices] ([Id], [CreatedDate], [CreatedUserId], [Currency], [IsDefault], [IsDisabled], [Name], [Price], [Priority], [ProductId], [Unit], [UnitQuantity], [UpdatedDate]) VALUES (25, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 1, 0, N'12 tháng', CAST(2040000.00 AS Decimal(18, 2)), 1, 8, N'tháng', 12, NULL)
SET IDENTITY_INSERT [dbo].[ProductPrices] OFF
SET IDENTITY_INSERT [dbo].[ProductProperties] ON 

INSERT [dbo].[ProductProperties] ([Id], [CreatedDate], [CreatedUserId], [IsDisabled], [IsHighlight], [Name], [Priority], [ProductId], [Unit], [UpdatedDate], [Value]) VALUES (1, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 0, N'Cloud Storage 40 GB', 1, 1, N'GB', NULL, CAST(40.00 AS Decimal(18, 2)))
INSERT [dbo].[ProductProperties] ([Id], [CreatedDate], [CreatedUserId], [IsDisabled], [IsHighlight], [Name], [Priority], [ProductId], [Unit], [UpdatedDate], [Value]) VALUES (2, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 0, N'RAM 2 GB', 2, 1, N'GB', NULL, CAST(2.00 AS Decimal(18, 2)))
INSERT [dbo].[ProductProperties] ([Id], [CreatedDate], [CreatedUserId], [IsDisabled], [IsHighlight], [Name], [Priority], [ProductId], [Unit], [UpdatedDate], [Value]) VALUES (3, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 1, N'CPU 3 Core', 3, 1, N'Core', NULL, CAST(3.00 AS Decimal(18, 2)))
INSERT [dbo].[ProductProperties] ([Id], [CreatedDate], [CreatedUserId], [IsDisabled], [IsHighlight], [Name], [Priority], [ProductId], [Unit], [UpdatedDate], [Value]) VALUES (4, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 1, N'Cloud Storage 80 GB', 1, 2, N'GB', NULL, CAST(80.00 AS Decimal(18, 2)))
INSERT [dbo].[ProductProperties] ([Id], [CreatedDate], [CreatedUserId], [IsDisabled], [IsHighlight], [Name], [Priority], [ProductId], [Unit], [UpdatedDate], [Value]) VALUES (5, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 0, N'RAM 4 GB', 2, 2, N'GB', NULL, CAST(4.00 AS Decimal(18, 2)))
INSERT [dbo].[ProductProperties] ([Id], [CreatedDate], [CreatedUserId], [IsDisabled], [IsHighlight], [Name], [Priority], [ProductId], [Unit], [UpdatedDate], [Value]) VALUES (6, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 1, N'CPU 4 Core', 3, 2, N'Core', NULL, CAST(4.00 AS Decimal(18, 2)))
INSERT [dbo].[ProductProperties] ([Id], [CreatedDate], [CreatedUserId], [IsDisabled], [IsHighlight], [Name], [Priority], [ProductId], [Unit], [UpdatedDate], [Value]) VALUES (7, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 0, N'Cloud Storage 120 GB', 1, 3, N'GB', NULL, CAST(120.00 AS Decimal(18, 2)))
INSERT [dbo].[ProductProperties] ([Id], [CreatedDate], [CreatedUserId], [IsDisabled], [IsHighlight], [Name], [Priority], [ProductId], [Unit], [UpdatedDate], [Value]) VALUES (8, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 1, N'RAM 6 GB', 2, 3, N'GB', NULL, CAST(6.00 AS Decimal(18, 2)))
INSERT [dbo].[ProductProperties] ([Id], [CreatedDate], [CreatedUserId], [IsDisabled], [IsHighlight], [Name], [Priority], [ProductId], [Unit], [UpdatedDate], [Value]) VALUES (9, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 1, N'CPU 6 Core', 3, 3, N'Core', NULL, CAST(6.00 AS Decimal(18, 2)))
INSERT [dbo].[ProductProperties] ([Id], [CreatedDate], [CreatedUserId], [IsDisabled], [IsHighlight], [Name], [Priority], [ProductId], [Unit], [UpdatedDate], [Value]) VALUES (10, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 1, N'Cloud Storage 160 GB', 1, 4, N'GB', NULL, CAST(160.00 AS Decimal(18, 2)))
INSERT [dbo].[ProductProperties] ([Id], [CreatedDate], [CreatedUserId], [IsDisabled], [IsHighlight], [Name], [Priority], [ProductId], [Unit], [UpdatedDate], [Value]) VALUES (11, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 1, N'RAM 10 GB', 2, 4, N'GB', NULL, CAST(10.00 AS Decimal(18, 2)))
INSERT [dbo].[ProductProperties] ([Id], [CreatedDate], [CreatedUserId], [IsDisabled], [IsHighlight], [Name], [Priority], [ProductId], [Unit], [UpdatedDate], [Value]) VALUES (12, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 1, N'CPU 8 Core', 3, 4, N'Core', NULL, CAST(8.00 AS Decimal(18, 2)))
INSERT [dbo].[ProductProperties] ([Id], [CreatedDate], [CreatedUserId], [IsDisabled], [IsHighlight], [Name], [Priority], [ProductId], [Unit], [UpdatedDate], [Value]) VALUES (13, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 0, N'Cloud Storage 40 GB', 1, 5, N'GB', NULL, CAST(40.00 AS Decimal(18, 2)))
INSERT [dbo].[ProductProperties] ([Id], [CreatedDate], [CreatedUserId], [IsDisabled], [IsHighlight], [Name], [Priority], [ProductId], [Unit], [UpdatedDate], [Value]) VALUES (14, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 0, N'RAM 2 GB', 2, 5, N'GB', NULL, CAST(2.00 AS Decimal(18, 2)))
INSERT [dbo].[ProductProperties] ([Id], [CreatedDate], [CreatedUserId], [IsDisabled], [IsHighlight], [Name], [Priority], [ProductId], [Unit], [UpdatedDate], [Value]) VALUES (15, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 1, N'CPU 3 Core', 3, 5, N'Core', NULL, CAST(3.00 AS Decimal(18, 2)))
INSERT [dbo].[ProductProperties] ([Id], [CreatedDate], [CreatedUserId], [IsDisabled], [IsHighlight], [Name], [Priority], [ProductId], [Unit], [UpdatedDate], [Value]) VALUES (16, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 1, N'Cloud Storage 80 GB', 1, 6, N'GB', NULL, CAST(80.00 AS Decimal(18, 2)))
INSERT [dbo].[ProductProperties] ([Id], [CreatedDate], [CreatedUserId], [IsDisabled], [IsHighlight], [Name], [Priority], [ProductId], [Unit], [UpdatedDate], [Value]) VALUES (17, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 0, N'RAM 4 GB', 2, 6, N'GB', NULL, CAST(4.00 AS Decimal(18, 2)))
INSERT [dbo].[ProductProperties] ([Id], [CreatedDate], [CreatedUserId], [IsDisabled], [IsHighlight], [Name], [Priority], [ProductId], [Unit], [UpdatedDate], [Value]) VALUES (18, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 1, N'CPU 4 Core', 3, 6, N'Core', NULL, CAST(4.00 AS Decimal(18, 2)))
INSERT [dbo].[ProductProperties] ([Id], [CreatedDate], [CreatedUserId], [IsDisabled], [IsHighlight], [Name], [Priority], [ProductId], [Unit], [UpdatedDate], [Value]) VALUES (19, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 0, N'Cloud Storage 120 GB', 1, 7, N'GB', NULL, CAST(120.00 AS Decimal(18, 2)))
INSERT [dbo].[ProductProperties] ([Id], [CreatedDate], [CreatedUserId], [IsDisabled], [IsHighlight], [Name], [Priority], [ProductId], [Unit], [UpdatedDate], [Value]) VALUES (20, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 1, N'RAM 6 GB', 2, 7, N'GB', NULL, CAST(6.00 AS Decimal(18, 2)))
INSERT [dbo].[ProductProperties] ([Id], [CreatedDate], [CreatedUserId], [IsDisabled], [IsHighlight], [Name], [Priority], [ProductId], [Unit], [UpdatedDate], [Value]) VALUES (21, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 1, N'CPU 6 Core', 3, 7, N'Core', NULL, CAST(6.00 AS Decimal(18, 2)))
INSERT [dbo].[ProductProperties] ([Id], [CreatedDate], [CreatedUserId], [IsDisabled], [IsHighlight], [Name], [Priority], [ProductId], [Unit], [UpdatedDate], [Value]) VALUES (22, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 1, N'Cloud Storage 160 GB', 1, 8, N'GB', NULL, CAST(160.00 AS Decimal(18, 2)))
INSERT [dbo].[ProductProperties] ([Id], [CreatedDate], [CreatedUserId], [IsDisabled], [IsHighlight], [Name], [Priority], [ProductId], [Unit], [UpdatedDate], [Value]) VALUES (23, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 1, N'RAM 10 GB', 2, 8, N'GB', NULL, CAST(10.00 AS Decimal(18, 2)))
INSERT [dbo].[ProductProperties] ([Id], [CreatedDate], [CreatedUserId], [IsDisabled], [IsHighlight], [Name], [Priority], [ProductId], [Unit], [UpdatedDate], [Value]) VALUES (24, CAST(N'2017-02-04T00:00:00.0000000' AS DateTime2), NULL, 0, 1, N'CPU 8 Core', 3, 8, N'Core', NULL, CAST(8.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[ProductProperties] OFF
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170123100109_Initial', N'1.1.0-rtm-22752')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170131155643_AddSetting', N'1.1.0-rtm-22752')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170205032311_AddMetaTag', N'1.1.0-rtm-22752')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170206025113_AddProductStatus', N'1.1.0-rtm-22752')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170206025414_AddQuantity', N'1.1.0-rtm-22752')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170208031930_UpdateSettingColumn', N'1.1.0-rtm-22752')
