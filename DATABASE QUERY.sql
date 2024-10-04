CREATE TABLE [dbo].[Booking] (
    [bookingID]      INT          IDENTITY (1, 1) NOT NULL,
    [custID]         CHAR (13)    NOT NULL,
    [roomID]         INT          NULL,
    [CheckInDate]    DATE         NOT NULL,
    [CheckOutDate]   DATE         NOT NULL,
    [Status]         VARCHAR (20) NOT NULL,
    [RequestDetails] TEXT         NULL,
    [NumberOfGuests] VARCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([bookingID] ASC),
    FOREIGN KEY ([custID]) REFERENCES [dbo].[Customer] ([custID]) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY ([roomID]) REFERENCES [dbo].[Room] ([roomID]) ON DELETE SET NULL ON UPDATE CASCADE,
    CHECK ([Status]='Pending' OR [Status]='Changed' OR [Status]='Completed' OR [Status]='Cancelled' OR [Status]='Confirmed'),
    CONSTRAINT [valid_dates] CHECK ([CheckOutDate]>[CheckInDate])
);


GO
CREATE NONCLUSTERED INDEX [idx_booking_customer]
    ON [dbo].[Booking]([custID] ASC);


GO
CREATE NONCLUSTERED INDEX [idx_booking_dates]
    ON [dbo].[Booking]([CheckInDate] ASC, [CheckOutDate] ASC);

--Customer
CREATE TABLE [dbo].[Customer] (
    [custID]  CHAR (13)       NOT NULL,
    [Name]    VARCHAR (100)   NOT NULL,
    [Surname] VARCHAR (100)   NOT NULL,
    [Phone]   VARCHAR (20)    NOT NULL,
    [Email]   VARCHAR (100)   NOT NULL,
    [Address] TEXT            NULL,
    [Balance] DECIMAL (10, 2) DEFAULT ((0)) NULL,
    [Status]  VARCHAR (20)    NOT NULL,
    PRIMARY KEY CLUSTERED ([custID] ASC),
    UNIQUE NONCLUSTERED ([Email] ASC),
    UNIQUE NONCLUSTERED ([Phone] ASC),
    CHECK ([Balance]>=(0)),
    CHECK ([Status]='Blacklisted' OR [Status]='Inactive' OR [Status]='Active')
);

--Booking System
CREATE TABLE [dbo].[BookingSystem] (
    [systemID] INT           IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (100) NOT NULL,
    [Version]  VARCHAR (20)  NOT NULL,
    PRIMARY KEY CLUSTERED ([systemID] ASC),
    UNIQUE NONCLUSTERED ([Name] ASC)
);

--Payment
CREATE TABLE [dbo].[Payment] (
    [paymentID] INT             IDENTITY (1, 1) NOT NULL,
    [bookingID] INT             NOT NULL,
    [Amount]    DECIMAL (10, 2) NOT NULL,
    [Date]      DATE            NOT NULL,
    [Method]    VARCHAR (50)    NOT NULL,
    PRIMARY KEY CLUSTERED ([paymentID] ASC),
    FOREIGN KEY ([bookingID]) REFERENCES [dbo].[Booking] ([bookingID]) ON DELETE CASCADE ON UPDATE CASCADE,
    CHECK ([Amount]>(0))
);


GO
CREATE NONCLUSTERED INDEX [idx_payment_booking]
    ON [dbo].[Payment]([bookingID] ASC);

--Receptionist
CREATE TABLE [dbo].[Receptionist] (
    [receptionistID] INT           IDENTITY (1, 1) NOT NULL,
    [Name]           VARCHAR (100) NOT NULL,
    [Surname]        VARCHAR (100) NOT NULL,
    [Phone]          VARCHAR (20)  NOT NULL,
    [Shift]          VARCHAR (20)  NOT NULL,
    [Email]          VARCHAR (100) NULL,
    [Password]       VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([receptionistID] ASC),
    UNIQUE NONCLUSTERED ([Phone] ASC),
    CHECK ([Shift]='Night' OR [Shift]='Afternoon' OR [Shift]='Morning')
);

--Reports
CREATE TABLE [dbo].[Reports] (
    [reportID] INT          IDENTITY (1, 1) NOT NULL,
    [Type]     VARCHAR (50) NOT NULL,
    [Date]     DATE         NOT NULL,
    [Content]  TEXT         NOT NULL,
    PRIMARY KEY CLUSTERED ([reportID] ASC)
);

--Room
CREATE TABLE [dbo].[Room] (
    [roomID]  INT             NOT NULL,
    [hotelID] INT             NOT NULL,
    [Status]  VARCHAR (20)    NOT NULL,
    [Number]  VARCHAR (20)    NOT NULL,
    [Type]    VARCHAR (50)    NOT NULL,
    [Rate]    DECIMAL (10, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([roomID] ASC),
    FOREIGN KEY ([hotelID]) REFERENCES [dbo].[Hotel] ([hotelID]) ON DELETE CASCADE ON UPDATE CASCADE,
    CHECK ([Status]='Maintenance' OR [Status]='Occupied' OR [Status]='Available'),
    CHECK ([Rate]>=(0))
);


GO
CREATE NONCLUSTERED INDEX [idx_room_hotel]
    ON [dbo].[Room]([hotelID] ASC);

