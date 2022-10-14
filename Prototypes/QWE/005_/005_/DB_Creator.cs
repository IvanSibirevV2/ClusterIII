using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
////////////////////////////////////////////////////////////////////////////
using Component;
using Component.SQL_Manager;
using Component.DataSource_LLS.Script;

namespace Component
{
    public static class DB_Creator
    {
        public static ISQL_M Do()
        {
            return
            (new Component.SQL_Manager.SQL_M())
                .Set_CheckExist_DB("QWE")//
                .Set((ISQL_M _this_SQL_M) =>
                {
                    
                    #region "TradeNode"
                    if(true)
                    if (!_this_SQL_M.Get_IsTable_Exists("TradeNode"))
                    {
                        _this_SQL_M.Get_InterfaceCopy().Set_p_SQL_String(
                            @"CREATE TABLE [dbo].[TradeNode]( "
                            + @"[id] [int] IDENTITY(0,1) NOT NULL, "
                            + @"[name] [nchar](10) NULL, "
                            + @"CONSTRAINT [PK_TradeNode] PRIMARY KEY CLUSTERED  "
                            + @"( "
                            + @"[id] ASC "
                            + @")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] "
                            + @") ON [PRIMARY] "
                            ).Do().Get_Resalt();
                        _this_SQL_M.Get_InterfaceCopy().Set_p_SQL_String(
                            @"INSERT INTO [QWE].[dbo].[TradeNode] ([name]) VALUES"
                            + @" ('Склад 1')"
                            + @" ,('Адрес 1')"
                            + @" ,('Адрес 2')"
                            + @" ,('Адрес 3')"
                            
                            ).Do().Get_Resalt();
                    }
                    #endregion
                    #region "EdgeOfGraph"
                    if (true)
                    if (!_this_SQL_M.Get_IsTable_Exists("EdgeOfGraph"))
                    {
                        _this_SQL_M.Get_InterfaceCopy().Set_p_SQL_String(
                            @"CREATE TABLE [dbo].[EdgeOfGraph]( "
                            + @"[id] [int] IDENTITY(1,1) NOT NULL, "
                            + @"[TradeNode_id_1] [int] NULL, "
                            + @"[TradeNode_id_2] [int] NULL, "
                            + @"[cost] [int] NULL, "
                            + @"CONSTRAINT [PK_EdgeOfGraph] PRIMARY KEY CLUSTERED  "
                            + @"( "
                            + @"[id] ASC "
                            + @")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] "
                            + @") ON [PRIMARY] "
                            ).Do().Get_Resalt();
                        _this_SQL_M.Get_InterfaceCopy().Set_p_SQL_String(//Создаём внешний ключ
                            @"ALTER TABLE [dbo].[EdgeOfGraph]  WITH CHECK ADD  CONSTRAINT [FK_EdgeOfGraph_TradeNode_id_1__TradeNode_id] FOREIGN KEY([TradeNode_id_1]) "
                            + @"REFERENCES [dbo].[TradeNode] ([id]) "
                            ).Do().Get_Resalt();
                        _this_SQL_M.Get_InterfaceCopy().Set_p_SQL_String(//Создаём внешний ключ
                            @"ALTER TABLE [dbo].[EdgeOfGraph]  WITH CHECK ADD  CONSTRAINT [FK_EdgeOfGraph_TradeNode_id_2__TradeNode_id] FOREIGN KEY([TradeNode_id_2]) "
                            + @"REFERENCES [dbo].[TradeNode] ([id]) "
                            ).Do().Get_Resalt();


                        _this_SQL_M.Get_InterfaceCopy().Set_p_SQL_String(
                            @"INSERT INTO [QWE].[dbo].[EdgeOfGraph]([TradeNode_id_1],[TradeNode_id_2],[cost]) VALUES "
                            + @"(1,3,30)" + @",(3,1,30)"
                            + @",(1,2,40)" + @",(2,1,40)"
                            + @",(3,2,10)" + @",(2,3,10)"
                            + @",(0,2,50)" + @",(2,0,50)"
                            + @",(0,3,20)" + @",(3,0,20)"
                            +@",(1,1,0)"
                            + @",(2,2,0)"
                            + @",(3,3,0)"
                            + @",(0,0,0)"
                            ).Do().Get_Resalt();
                    }
                    #endregion


                    #region"CarList"
                    if (true)
                    if (!_this_SQL_M.Get_IsTable_Exists("CarList"))
                    {
                        _this_SQL_M.Get_InterfaceCopy().Set_p_SQL_String(
                            @"CREATE TABLE [dbo].[CarList]( "
                            + @"[id] [int] IDENTITY(0,1) NOT NULL, "
                            + @"[name] [nchar](10) NULL, "
                            + @"[maxLoadCapacity] [int] NULL, "
                            + @"CONSTRAINT [PK_CarList] PRIMARY KEY CLUSTERED "
                            + @"( "
                            + @"[id] ASC "
                            + @")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] "
                            + @") ON [PRIMARY] "
                            ).Do().Get_Resalt();
                        
                        _this_SQL_M.Get_InterfaceCopy().Set_p_SQL_String(
                            @"INSERT INTO [QWE].[dbo].[CarList] ([name],[maxLoadCapacity]) VALUES "
                            + @"('ЗапСклад',1000)"
                            + @",('MAP-5337',8) "
                            + @",('W16',4) "
                            + @",('W32',8)"
                            ).Do().Get_Resalt();
                        
                    }
                    #endregion
                    #region"RouteList"
                    if (true)
                    if (!_this_SQL_M.Get_IsTable_Exists("RouteList"))
                    {
                        _this_SQL_M.Get_InterfaceCopy().Set_p_SQL_String(
                                @"CREATE TABLE [dbo].[RouteList]( "
                            + @"[id] [int] IDENTITY(1,1) NOT NULL, "
                            + @"[TradeNode_id_1] [int] NULL, "
                            + @"[TradeNode_id_2] [int] NULL, "
                            + @"[CarList_id] [int] NULL, "
                            + @"[reset] [int] NULL, "
                            + @"CONSTRAINT [PK_RouteList] PRIMARY KEY CLUSTERED "
                            + @"( "
                            + @"[id] ASC "
                            + @")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] "
                            + @") ON [PRIMARY] "
                            ).Do().Get_Resalt();
                        _this_SQL_M.Get_InterfaceCopy().Set_p_SQL_String(//Создаём внешний ключ
                            @"ALTER TABLE [dbo].[RouteList]  WITH CHECK ADD  CONSTRAINT [FK_RouteList_TradeNode_id_1__TradeNode_id] FOREIGN KEY([TradeNode_id_1]) "
                            + @"REFERENCES [dbo].[TradeNode] ([id]) "
                            ).Do().Get_Resalt();
                        _this_SQL_M.Get_InterfaceCopy().Set_p_SQL_String(//Создаём внешний ключ
                            @"ALTER TABLE [dbo].[RouteList]  WITH CHECK ADD  CONSTRAINT [FK_RouteList_TradeNode_id_2__TradeNode_id] FOREIGN KEY([TradeNode_id_2]) "
                            + @"REFERENCES [dbo].[TradeNode] ([id]) "
                            ).Do().Get_Resalt();
                        _this_SQL_M.Get_InterfaceCopy().Set_p_SQL_String(//Создаём внешний ключ
                            @"ALTER TABLE [dbo].[RouteList]  WITH CHECK ADD  CONSTRAINT [FK_RouteList_CarList_id__CarList_id] FOREIGN KEY([CarList_id]) "
                            + @"REFERENCES [dbo].[CarList] ([id]) "
                            ).Do().Get_Resalt();
                        
                        _this_SQL_M.Get_InterfaceCopy().Set_p_SQL_String(
                            @"INSERT INTO [QWE].[dbo].[RouteList] ([TradeNode_id_1],[TradeNode_id_2],[CarList_id],[reset]) VALUES "
                            //Заполение списка заказов
                            + @"(1,1,0,-10)"
                            + @",(1,1,0,-10)"
                            + @",(1,1,0,-10)"
                            + @",(1,1,0,-10)"
                            + @",(2,2,0,-10)"
                            + @",(2,2,0,-10)"
                            + @",(2,2,0,-10)"
                            + @",(3,3,0,-10)"
                            + @",(3,3,0,-10)"
                            //Заполение склада
                            //+ @",(0,0,0,100)"
                            + @",(0,0,0,10)"
                            + @",(0,0,0,10)"
                            + @",(0,0,0,10)"
                            + @",(0,0,0,10)"
                            + @",(0,0,0,10)"
                            + @",(0,0,0,10)"
                            + @",(0,0,0,10)"
                            + @",(0,0,0,10)"
                            + @",(0,0,0,10)"
                            //Заполение склада машинами
                            + @",(0,0,1,0)"
                            + @",(0,0,2,0)"
                            + @",(0,0,3,0)"
                            ).Do().Get_Resalt();                        
                    }
                    #endregion
                })
            ;
        }
    }
}