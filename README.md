# Warehouse Console Application

## Project Description
A .NET console application for warehouse management that handles pallets and boxes with the following requirements.

## Requirements

### Class Hierarchy
- **Pallet**:
  - Properties: `ID`, `Width`, `Height`, `Depth`, `Weight`, `Boxes` (list of boxes).
  - Can contain boxes.
  - Pallet expiration date is determined by the earliest expiration date of its boxes.
  - Weight = sum of box weights + 30kg.
  - Volume = sum of box volumes + (Width × Height × Depth).

- **Box**:
  - Properties: `ID`, `Width`, `Height`, `Depth`, `Weight`.
  - Must have either an `ExpirationDate` or `ProductionDate`.
    - If `ProductionDate` is provided, `ExpirationDate = ProductionDate + 100 days`.
    - Dates are stored without time (e.g., `01.01.2023`).
  - Volume = Width × Height × Depth.
  - Box dimensions must not exceed the containing pallet's width and depth.

### Console Application
1. **Data Input** (choose one method):
   - In-memory generation.
   - File or database reading.
   - User input.

2. **Output**:
   - Group all pallets by expiration date → sort groups by ascending expiration date → sort pallets in each group by weight.
   - Display the **top 3 pallets** with boxes having the furthest expiration dates, sorted by ascending volume.

### Optional
- Unit test coverage.
- Follow [Microsoft C# Coding Conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions).
- *(Bonus)* Replace console app with a full UI (does not affect evaluation).

## Implementation Notes
- Use OOP principles for class design.
- Ensure proper validation (e.g., box fits pallet dimensions).
- Include error handling for data loading.  

# Domain models  
```mermaid  
classDiagram
    class Warehouse {
        +Int identifier
        +String name
        +Address location
        +Set~BufferZone~ buffers
        +Set~StorageZone~ zones
        +Set~Ramp~ ramps
    }
    
    class Address {
        +Int identifier
        +String street
        +String city
        +String state
        +String postalCode
        +String country
        +GeoCoordinate coordinates
    }
    
    class GeoCoordinate {
        +int identifier
        +decimal latitude
        +decimal longitude
    }
    
    class BufferZone {
        +Int identifier
        +LoadCapacity capacity
        +Dimensions spaceAvailable
        +Status status
    }
    
    class LoadCapacity {
        +Int identifier
        +decimal maxWeight
        +decimal maxVolume
    }
    
    class Dimensions {
        +Int identifier
        +decimal length
        +decimal width
        +decimal height
        +decimal volume
        +decimal weight
    }
    
    class StorageZone {
        +Int identifier
        +String code
        +ClimatRegime regime
        +Set~StorageRack~ racks
    }
    
    class ClimatRegime {
        +Int identifier
        +TemperatureRange tempRange
        +HumidityRange humidityRange
    }
    
    class TemperatureRange {
        Int identifier
        +decimal minTemperture
        +decimal maxTemperature
    }
    
    class HumidityRange {
        Int identifier
        +decimal minPercent
        +decimal maxPercent
    }
    
    class StorageRack {
        +Int identifier
        +Int levels
        +LoadCapacity capacity
        +Set~StorageSection~ sections
    }
    
    class StorageSection {
        +Int identifier
        +String code
        +Int shells
        +Set~StorageBin~ bins
    }
    
    class StorageBin {
        +Int identifier
        +Int shell
        +int code
        +String barcode
        +BinStatus status
        +Dimensions dimensions
        +LoadCapacity capacity
        +Set~StorageItem~ items
    }
    
    class Ramp {
        +Int identifier
        +Char gate
        +Int status
    }

    Warehouse "1" *-- "1" Address
    Address "1" *-- "1" GeoCoordinate
    
    Warehouse "1" *-- "1" BufferZone
    BufferZone "1" *-- "1" Dimensions
    BufferZone "1" *-- "1" LoadCapacity
    
    Warehouse "1" *-- "1..*" StorageZone
    StorageZone "1" *-- "1" ClimatRegime
    ClimatRegime "1" *-- "1" TemperatureRange
    ClimatRegime "1" *-- "1" HumidityRange
    
    StorageZone "1" *-- "1..*" StorageRack
    StorageRack "1" *-- "1..*" StorageSection
    StorageSection "1" *-- "1..*" StorageBin
    StorageBin "1" *-- "1" Dimensions
    StorageBin "1" *-- "1" LoadCapacity
    
    Warehouse "1" *-- "1..*" Ramp
```  
  
# Enumerations  
```mermaid  
 classDiagram
 %% Enumerations
    class ItemStatus {
        <<enumeration>>
        IN_STOCK
        RESERVED
        IN_TRANSIT
    }

    class DeliveryStatus {
        <<enumeration>>
        CREATED
        IN_TRANSIT
        ARRIVED
        UNLOADING
        COMPLETED
        DELAYED
        CANCELLED
    }

    class BinStatus {
        <<enumeration>>
        AVAILABLE
        OCCUPIED
        RESERVED
    }

    class TaskPriority {
        <<enumeration>>
        CRITICAL
        HIGH
        MEDIUM
        LOW
    }

    class MovementReason {
        <<enumeration>>
        RECEIVING
        PICKING
        REORGANIZATION
        QUALITY_CHECK
    }
```

