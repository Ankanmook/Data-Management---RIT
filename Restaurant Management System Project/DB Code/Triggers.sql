Trigger to generate TableId and MealOrderId from Table and Meal Order on inserting Patron
GO

CREATE TRIGGER [dbo].[orderTable_trigger]
on dbo.Patron
AFTER INSERT 
AS
INSERT INTO [dbo].[Table] ( [DateTime],[Capacity])
VALUES (GETDATE(),1)
INSERT INTO [dbo].[MealOrder] ([BillAmount],[Time])
VALUES (0,GETDATE())
INSERT INTO [dbo].[PatronGIVESOrder]([TableID],[PatronID],[MealOrderID])
select (select max(TableID)from [dbo].[Table]),PatronID,((select max(MealOrderID)from [dbo].[MealOrder])) from inserted
GO

Trigger to Delete values of corresponding product from Supplies when certain product is deleted.
GO

CREATE TRIGGER delete_supplier
ON dbo.PURCHASE
AFTER DELETE
AS
DELETE FROM dbo.SUPPLIES WHERE
PRODUCTID = ( Select ProductID from inserted)

GO


