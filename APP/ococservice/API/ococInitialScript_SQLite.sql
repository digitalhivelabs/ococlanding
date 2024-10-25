CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "ClassificationItems" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_ClassificationItems" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NULL,
    "Abbr" TEXT NULL
);

CREATE TABLE "QualityStandards" (
    "QSId" INTEGER NOT NULL CONSTRAINT "PK_QualityStandards" PRIMARY KEY AUTOINCREMENT,
    "Organization" TEXT NULL,
    "Abbr" TEXT NULL,
    "Country" TEXT NULL,
    "MDate" TEXT NOT NULL
);

CREATE TABLE "Semaphore" (
    "SemaphoreId" INTEGER NOT NULL CONSTRAINT "PK_Semaphore" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NULL,
    "Color" TEXT NULL,
    "Hex" TEXT NULL
);

CREATE TABLE "surveys" (
    "SurveyId" INTEGER NOT NULL CONSTRAINT "PK_surveys" PRIMARY KEY AUTOINCREMENT,
    "CDate" TEXT NOT NULL,
    "LocationName" TEXT NULL,
    "LocationLatLon" TEXT NULL
);

CREATE TABLE "Units" (
    "UnitId" INTEGER NOT NULL CONSTRAINT "PK_Units" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NULL,
    "Abbr" TEXT NULL,
    "BaseUnitId" INTEGER NULL,
    CONSTRAINT "FK_Units_Units_BaseUnitId" FOREIGN KEY ("BaseUnitId") REFERENCES "Units" ("UnitId")
);

CREATE TABLE "Users" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Users" PRIMARY KEY AUTOINCREMENT,
    "UserName" TEXT NOT NULL,
    "PasswordHash" BLOB NULL,
    "PasswordSalt" BLOB NULL,
    "Email" TEXT NULL,
    "Status" TEXT NULL,
    "Country" TEXT NULL,
    "Role" TEXT NULL,
    "Job" TEXT NULL,
    "Gender" TEXT NULL,
    "StartDate" TEXT NOT NULL,
    "RegistrationDate" TEXT NOT NULL,
    "IsActive" INTEGER NOT NULL
);

CREATE TABLE "Conversions" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Conversions" PRIMARY KEY AUTOINCREMENT,
    "Operator" TEXT NULL,
    "Factor" REAL NOT NULL,
    "Formula" TEXT NULL,
    "SourceUnitId" INTEGER NOT NULL,
    "TargetUnitId" INTEGER NOT NULL,
    CONSTRAINT "FK_Conversions_Units_SourceUnitId" FOREIGN KEY ("SourceUnitId") REFERENCES "Units" ("UnitId") ON DELETE RESTRICT,
    CONSTRAINT "FK_Conversions_Units_TargetUnitId" FOREIGN KEY ("TargetUnitId") REFERENCES "Units" ("UnitId") ON DELETE RESTRICT
);

CREATE TABLE "Items" (
    "itemId" INTEGER NOT NULL CONSTRAINT "PK_Items" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NULL,
    "Abbr" TEXT NULL,
    "MoreInfo" TEXT NULL,
    "UnitId" INTEGER NOT NULL,
    "ClassificationItemId" INTEGER NULL,
    CONSTRAINT "FK_Items_ClassificationItems_ClassificationItemId" FOREIGN KEY ("ClassificationItemId") REFERENCES "ClassificationItems" ("Id"),
    CONSTRAINT "FK_Items_Units_UnitId" FOREIGN KEY ("UnitId") REFERENCES "Units" ("UnitId") ON DELETE RESTRICT
);

CREATE TABLE "QualityStandardItems" (
    "QSIId" INTEGER NOT NULL CONSTRAINT "PK_QualityStandardItems" PRIMARY KEY AUTOINCREMENT,
    "QualityStandardQSId" INTEGER NULL,
    "LowerLim" REAL NOT NULL,
    "UpperLim" REAL NOT NULL,
    "LatLog" TEXT NULL,
    "QSId" INTEGER NOT NULL,
    "ItemId" INTEGER NOT NULL,
    "UnitId" INTEGER NOT NULL,
    "SemaphoreId" INTEGER NOT NULL,
    CONSTRAINT "FK_QualityStandardItems_Items_ItemId" FOREIGN KEY ("ItemId") REFERENCES "Items" ("itemId") ON DELETE RESTRICT,
    CONSTRAINT "FK_QualityStandardItems_QualityStandards_QualityStandardQSId" FOREIGN KEY ("QualityStandardQSId") REFERENCES "QualityStandards" ("QSId"),
    CONSTRAINT "FK_QualityStandardItems_Semaphore_SemaphoreId" FOREIGN KEY ("SemaphoreId") REFERENCES "Semaphore" ("SemaphoreId") ON DELETE RESTRICT,
    CONSTRAINT "FK_QualityStandardItems_Units_UnitId" FOREIGN KEY ("UnitId") REFERENCES "Units" ("UnitId") ON DELETE RESTRICT
);

CREATE TABLE "surveyItems" (
    "SIId" INTEGER NOT NULL CONSTRAINT "PK_surveyItems" PRIMARY KEY AUTOINCREMENT,
    "Value" REAL NOT NULL,
    "ValueBase" REAL NOT NULL,
    "Method" TEXT NULL,
    "LabName" TEXT NULL,
    "Responsible" INTEGER NOT NULL,
    "Preferent" INTEGER NOT NULL,
    "Notes" TEXT NULL,
    "SurveyId" INTEGER NOT NULL,
    "ItemId" INTEGER NOT NULL,
    "UnitId" INTEGER NOT NULL,
    "UnitBaseId" INTEGER NOT NULL,
    CONSTRAINT "FK_surveyItems_Items_ItemId" FOREIGN KEY ("ItemId") REFERENCES "Items" ("itemId") ON DELETE RESTRICT,
    CONSTRAINT "FK_surveyItems_Units_UnitBaseId" FOREIGN KEY ("UnitBaseId") REFERENCES "Units" ("UnitId") ON DELETE RESTRICT,
    CONSTRAINT "FK_surveyItems_Units_UnitId" FOREIGN KEY ("UnitId") REFERENCES "Units" ("UnitId") ON DELETE RESTRICT,
    CONSTRAINT "FK_surveyItems_surveys_SurveyId" FOREIGN KEY ("SurveyId") REFERENCES "surveys" ("SurveyId") ON DELETE RESTRICT
);

CREATE INDEX "IX_Conversions_SourceUnitId" ON "Conversions" ("SourceUnitId");

CREATE INDEX "IX_Conversions_TargetUnitId" ON "Conversions" ("TargetUnitId");

CREATE INDEX "IX_Items_ClassificationItemId" ON "Items" ("ClassificationItemId");

CREATE INDEX "IX_Items_UnitId" ON "Items" ("UnitId");

CREATE INDEX "IX_QualityStandardItems_ItemId" ON "QualityStandardItems" ("ItemId");

CREATE INDEX "IX_QualityStandardItems_QualityStandardQSId" ON "QualityStandardItems" ("QualityStandardQSId");

CREATE INDEX "IX_QualityStandardItems_SemaphoreId" ON "QualityStandardItems" ("SemaphoreId");

CREATE INDEX "IX_QualityStandardItems_UnitId" ON "QualityStandardItems" ("UnitId");

CREATE INDEX "IX_surveyItems_ItemId" ON "surveyItems" ("ItemId");

CREATE INDEX "IX_surveyItems_SurveyId" ON "surveyItems" ("SurveyId");

CREATE INDEX "IX_surveyItems_UnitBaseId" ON "surveyItems" ("UnitBaseId");

CREATE INDEX "IX_surveyItems_UnitId" ON "surveyItems" ("UnitId");

CREATE INDEX "IX_Units_BaseUnitId" ON "Units" ("BaseUnitId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240316203047_InitialCreate', '7.0.15');

COMMIT;

