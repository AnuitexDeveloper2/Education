import { CurrencyType } from 'src/app/shared/enums/CurrencyType';
import { ProductType } from 'src/app/shared/enums/ProductType';
import { AuthorModel } from 'src/app/shared/models/author/AuthorModel';
import { BaseModel } from 'src/app/shared/models/Base/BaseModel';

export class PrintingEditionModelItem extends BaseModel 
{
    id: number;
    title: string;
    description: string;
    price: number;
    currency: CurrencyType;
    type: ProductType;
    authors: AuthorModel;

}