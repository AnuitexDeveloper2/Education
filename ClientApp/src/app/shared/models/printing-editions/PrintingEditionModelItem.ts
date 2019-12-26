import { CurrencyType } from 'src/app/shared/enums/CurrencyType';
import { ProductType } from 'src/app/shared/enums/ProductType';
import { AuthorModel } from 'src/app/shared/models/author/AuthorModel';

export class PrintingEditionModelItem{
    id: number;
    title: string;
    description: string;
    price: number;
    currency: CurrencyType;
    type: ProductType;
    authors: AuthorModel;
}