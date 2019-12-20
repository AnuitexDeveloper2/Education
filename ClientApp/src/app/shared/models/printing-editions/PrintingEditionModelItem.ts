import { CurrencyType } from '../../enums/CurrencyType';
import { ProductType } from '../../enums/ProductType';
import { AuthorModel } from '../author/AuthorModel';

export class PrintingeditionModelItem{
    id: number;
    title: string;
    description: string;
    price: number;
    currency: CurrencyType;
    type: ProductType;
    authors: AuthorModel;
}