    export function enumSelector(definition) {
        let enumValues:Array<string>= [];
        for(let value in definition) {
            if(value.length>1) {
                enumValues.push(value);
            }
        }
        return enumValues;
    }

    export function ListEnum<T>(name:string,definition) {
        for(let value in definition) {
            if(name == value) {
               return value;
            }
        }
    }
