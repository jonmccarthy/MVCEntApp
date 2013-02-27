﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PizzaStore.Domain.EntityModels
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="PizzaSystem")]
	public partial class DisplayOrderDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertOrder(Order instance);
    partial void UpdateOrder(Order instance);
    partial void DeleteOrder(Order instance);
    partial void InsertOrderItem(OrderItem instance);
    partial void UpdateOrderItem(OrderItem instance);
    partial void DeleteOrderItem(OrderItem instance);
    partial void InsertDeliveryDetail(DeliveryDetail instance);
    partial void UpdateDeliveryDetail(DeliveryDetail instance);
    partial void DeleteDeliveryDetail(DeliveryDetail instance);
    #endregion
		
		public DisplayOrderDataContext() : 
				base(global::PizzaStore.Domain.Properties.Settings.Default.PizzaSystemConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DisplayOrderDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DisplayOrderDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DisplayOrderDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DisplayOrderDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Order> Orders
		{
			get
			{
				return this.GetTable<Order>();
			}
		}
		
		public System.Data.Linq.Table<OrderItem> OrderItems
		{
			get
			{
				return this.GetTable<OrderItem>();
			}
		}
		
		public System.Data.Linq.Table<DeliveryDetail> DeliveryDetails
		{
			get
			{
				return this.GetTable<DeliveryDetail>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Orders")]
	public partial class Order : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _OrdersID;
		
		private System.Nullable<int> _FKMenuCustomerID;
		
		private System.Nullable<int> _FKDeliveryID;
		
		private System.DateTime _DateOrder;
		
		private EntitySet<OrderItem> _OrderItems;
		
		private EntitySet<DeliveryDetail> _DeliveryDetails;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnOrdersIDChanging(int value);
    partial void OnOrdersIDChanged();
    partial void OnFKMenuCustomerIDChanging(System.Nullable<int> value);
    partial void OnFKMenuCustomerIDChanged();
    partial void OnFKDeliveryIDChanging(System.Nullable<int> value);
    partial void OnFKDeliveryIDChanged();
    partial void OnDateOrderChanging(System.DateTime value);
    partial void OnDateOrderChanged();
    #endregion
		
		public Order()
		{
			this._OrderItems = new EntitySet<OrderItem>(new Action<OrderItem>(this.attach_OrderItems), new Action<OrderItem>(this.detach_OrderItems));
			this._DeliveryDetails = new EntitySet<DeliveryDetail>(new Action<DeliveryDetail>(this.attach_DeliveryDetails), new Action<DeliveryDetail>(this.detach_DeliveryDetails));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OrdersID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int OrdersID
		{
			get
			{
				return this._OrdersID;
			}
			set
			{
				if ((this._OrdersID != value))
				{
					this.OnOrdersIDChanging(value);
					this.SendPropertyChanging();
					this._OrdersID = value;
					this.SendPropertyChanged("OrdersID");
					this.OnOrdersIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FKMenuCustomerID", DbType="Int")]
		public System.Nullable<int> FKMenuCustomerID
		{
			get
			{
				return this._FKMenuCustomerID;
			}
			set
			{
				if ((this._FKMenuCustomerID != value))
				{
					this.OnFKMenuCustomerIDChanging(value);
					this.SendPropertyChanging();
					this._FKMenuCustomerID = value;
					this.SendPropertyChanged("FKMenuCustomerID");
					this.OnFKMenuCustomerIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FKDeliveryID", DbType="Int")]
		public System.Nullable<int> FKDeliveryID
		{
			get
			{
				return this._FKDeliveryID;
			}
			set
			{
				if ((this._FKDeliveryID != value))
				{
					this.OnFKDeliveryIDChanging(value);
					this.SendPropertyChanging();
					this._FKDeliveryID = value;
					this.SendPropertyChanged("FKDeliveryID");
					this.OnFKDeliveryIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateOrder", DbType="DateTime NOT NULL")]
		public System.DateTime DateOrder
		{
			get
			{
				return this._DateOrder;
			}
			set
			{
				if ((this._DateOrder != value))
				{
					this.OnDateOrderChanging(value);
					this.SendPropertyChanging();
					this._DateOrder = value;
					this.SendPropertyChanged("DateOrder");
					this.OnDateOrderChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Order_OrderItem", Storage="_OrderItems", ThisKey="OrdersID", OtherKey="FKOrdersID")]
		public EntitySet<OrderItem> OrderItems
		{
			get
			{
				return this._OrderItems;
			}
			set
			{
				this._OrderItems.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Order_DeliveryDetail", Storage="_DeliveryDetails", ThisKey="OrdersID", OtherKey="FKOrderID")]
		public EntitySet<DeliveryDetail> DeliveryDetails
		{
			get
			{
				return this._DeliveryDetails;
			}
			set
			{
				this._DeliveryDetails.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_OrderItems(OrderItem entity)
		{
			this.SendPropertyChanging();
			entity.Order = this;
		}
		
		private void detach_OrderItems(OrderItem entity)
		{
			this.SendPropertyChanging();
			entity.Order = null;
		}
		
		private void attach_DeliveryDetails(DeliveryDetail entity)
		{
			this.SendPropertyChanging();
			entity.Order = this;
		}
		
		private void detach_DeliveryDetails(DeliveryDetail entity)
		{
			this.SendPropertyChanging();
			entity.Order = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.OrderItems")]
	public partial class OrderItem : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _OrderItemsID;
		
		private System.Nullable<int> _FKOrdersID;
		
		private string _ProductName;
		
		private string _ProductDescription;
		
		private int _Quantity;
		
		private decimal _Price;
		
		private EntityRef<Order> _Order;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnOrderItemsIDChanging(int value);
    partial void OnOrderItemsIDChanged();
    partial void OnFKOrdersIDChanging(System.Nullable<int> value);
    partial void OnFKOrdersIDChanged();
    partial void OnProductNameChanging(string value);
    partial void OnProductNameChanged();
    partial void OnProductDescriptionChanging(string value);
    partial void OnProductDescriptionChanged();
    partial void OnQuantityChanging(int value);
    partial void OnQuantityChanged();
    partial void OnPriceChanging(decimal value);
    partial void OnPriceChanged();
    #endregion
		
		public OrderItem()
		{
			this._Order = default(EntityRef<Order>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OrderItemsID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int OrderItemsID
		{
			get
			{
				return this._OrderItemsID;
			}
			set
			{
				if ((this._OrderItemsID != value))
				{
					this.OnOrderItemsIDChanging(value);
					this.SendPropertyChanging();
					this._OrderItemsID = value;
					this.SendPropertyChanged("OrderItemsID");
					this.OnOrderItemsIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FKOrdersID", DbType="Int")]
		public System.Nullable<int> FKOrdersID
		{
			get
			{
				return this._FKOrdersID;
			}
			set
			{
				if ((this._FKOrdersID != value))
				{
					if (this._Order.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnFKOrdersIDChanging(value);
					this.SendPropertyChanging();
					this._FKOrdersID = value;
					this.SendPropertyChanged("FKOrdersID");
					this.OnFKOrdersIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProductName", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string ProductName
		{
			get
			{
				return this._ProductName;
			}
			set
			{
				if ((this._ProductName != value))
				{
					this.OnProductNameChanging(value);
					this.SendPropertyChanging();
					this._ProductName = value;
					this.SendPropertyChanged("ProductName");
					this.OnProductNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProductDescription", DbType="Text NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string ProductDescription
		{
			get
			{
				return this._ProductDescription;
			}
			set
			{
				if ((this._ProductDescription != value))
				{
					this.OnProductDescriptionChanging(value);
					this.SendPropertyChanging();
					this._ProductDescription = value;
					this.SendPropertyChanged("ProductDescription");
					this.OnProductDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Quantity", DbType="Int NOT NULL")]
		public int Quantity
		{
			get
			{
				return this._Quantity;
			}
			set
			{
				if ((this._Quantity != value))
				{
					this.OnQuantityChanging(value);
					this.SendPropertyChanging();
					this._Quantity = value;
					this.SendPropertyChanged("Quantity");
					this.OnQuantityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="Money NOT NULL")]
		public decimal Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this.OnPriceChanging(value);
					this.SendPropertyChanging();
					this._Price = value;
					this.SendPropertyChanged("Price");
					this.OnPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Order_OrderItem", Storage="_Order", ThisKey="FKOrdersID", OtherKey="OrdersID", IsForeignKey=true)]
		public Order Order
		{
			get
			{
				return this._Order.Entity;
			}
			set
			{
				Order previousValue = this._Order.Entity;
				if (((previousValue != value) 
							|| (this._Order.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Order.Entity = null;
						previousValue.OrderItems.Remove(this);
					}
					this._Order.Entity = value;
					if ((value != null))
					{
						value.OrderItems.Add(this);
						this._FKOrdersID = value.OrdersID;
					}
					else
					{
						this._FKOrdersID = default(Nullable<int>);
					}
					this.SendPropertyChanged("Order");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.DeliveryDetails")]
	public partial class DeliveryDetail : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _DeliveryID;
		
		private System.Nullable<int> _FKOrderID;
		
		private string _Firstname;
		
		private string _Surname;
		
		private string _ContactPhone;
		
		private string _Address1;
		
		private string _Address2;
		
		private string _Address3;
		
		private string _County;
		
		private string _Country;
		
		private EntityRef<Order> _Order;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnDeliveryIDChanging(int value);
    partial void OnDeliveryIDChanged();
    partial void OnFKOrderIDChanging(System.Nullable<int> value);
    partial void OnFKOrderIDChanged();
    partial void OnFirstnameChanging(string value);
    partial void OnFirstnameChanged();
    partial void OnSurnameChanging(string value);
    partial void OnSurnameChanged();
    partial void OnContactPhoneChanging(string value);
    partial void OnContactPhoneChanged();
    partial void OnAddress1Changing(string value);
    partial void OnAddress1Changed();
    partial void OnAddress2Changing(string value);
    partial void OnAddress2Changed();
    partial void OnAddress3Changing(string value);
    partial void OnAddress3Changed();
    partial void OnCountyChanging(string value);
    partial void OnCountyChanged();
    partial void OnCountryChanging(string value);
    partial void OnCountryChanged();
    #endregion
		
		public DeliveryDetail()
		{
			this._Order = default(EntityRef<Order>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DeliveryID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int DeliveryID
		{
			get
			{
				return this._DeliveryID;
			}
			set
			{
				if ((this._DeliveryID != value))
				{
					this.OnDeliveryIDChanging(value);
					this.SendPropertyChanging();
					this._DeliveryID = value;
					this.SendPropertyChanged("DeliveryID");
					this.OnDeliveryIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FKOrderID", DbType="Int")]
		public System.Nullable<int> FKOrderID
		{
			get
			{
				return this._FKOrderID;
			}
			set
			{
				if ((this._FKOrderID != value))
				{
					if (this._Order.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnFKOrderIDChanging(value);
					this.SendPropertyChanging();
					this._FKOrderID = value;
					this.SendPropertyChanged("FKOrderID");
					this.OnFKOrderIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Firstname", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string Firstname
		{
			get
			{
				return this._Firstname;
			}
			set
			{
				if ((this._Firstname != value))
				{
					this.OnFirstnameChanging(value);
					this.SendPropertyChanging();
					this._Firstname = value;
					this.SendPropertyChanged("Firstname");
					this.OnFirstnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Surname", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string Surname
		{
			get
			{
				return this._Surname;
			}
			set
			{
				if ((this._Surname != value))
				{
					this.OnSurnameChanging(value);
					this.SendPropertyChanging();
					this._Surname = value;
					this.SendPropertyChanged("Surname");
					this.OnSurnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ContactPhone", DbType="NVarChar(45) NOT NULL", CanBeNull=false)]
		public string ContactPhone
		{
			get
			{
				return this._ContactPhone;
			}
			set
			{
				if ((this._ContactPhone != value))
				{
					this.OnContactPhoneChanging(value);
					this.SendPropertyChanging();
					this._ContactPhone = value;
					this.SendPropertyChanged("ContactPhone");
					this.OnContactPhoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Address1", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string Address1
		{
			get
			{
				return this._Address1;
			}
			set
			{
				if ((this._Address1 != value))
				{
					this.OnAddress1Changing(value);
					this.SendPropertyChanging();
					this._Address1 = value;
					this.SendPropertyChanged("Address1");
					this.OnAddress1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Address2", DbType="NVarChar(255)")]
		public string Address2
		{
			get
			{
				return this._Address2;
			}
			set
			{
				if ((this._Address2 != value))
				{
					this.OnAddress2Changing(value);
					this.SendPropertyChanging();
					this._Address2 = value;
					this.SendPropertyChanged("Address2");
					this.OnAddress2Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Address3", DbType="NVarChar(255)")]
		public string Address3
		{
			get
			{
				return this._Address3;
			}
			set
			{
				if ((this._Address3 != value))
				{
					this.OnAddress3Changing(value);
					this.SendPropertyChanging();
					this._Address3 = value;
					this.SendPropertyChanged("Address3");
					this.OnAddress3Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_County", DbType="NVarChar(45) NOT NULL", CanBeNull=false)]
		public string County
		{
			get
			{
				return this._County;
			}
			set
			{
				if ((this._County != value))
				{
					this.OnCountyChanging(value);
					this.SendPropertyChanging();
					this._County = value;
					this.SendPropertyChanged("County");
					this.OnCountyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Country", DbType="NVarChar(255)")]
		public string Country
		{
			get
			{
				return this._Country;
			}
			set
			{
				if ((this._Country != value))
				{
					this.OnCountryChanging(value);
					this.SendPropertyChanging();
					this._Country = value;
					this.SendPropertyChanged("Country");
					this.OnCountryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Order_DeliveryDetail", Storage="_Order", ThisKey="FKOrderID", OtherKey="OrdersID", IsForeignKey=true)]
		public Order Order
		{
			get
			{
				return this._Order.Entity;
			}
			set
			{
				Order previousValue = this._Order.Entity;
				if (((previousValue != value) 
							|| (this._Order.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Order.Entity = null;
						previousValue.DeliveryDetails.Remove(this);
					}
					this._Order.Entity = value;
					if ((value != null))
					{
						value.DeliveryDetails.Add(this);
						this._FKOrderID = value.OrdersID;
					}
					else
					{
						this._FKOrderID = default(Nullable<int>);
					}
					this.SendPropertyChanged("Order");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
