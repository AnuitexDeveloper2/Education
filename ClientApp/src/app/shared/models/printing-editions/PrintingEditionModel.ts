import { PrintingEditionModelItem } from 'src/app/shared/models/printing-editions/PrintingEditionModelItem';
import { BaseModel } from 'src/app/shared/models/Base/BaseModel';

export class PrintingEditionModel extends BaseModel {

    count: number;
    items: Array<PrintingEditionModelItem>;

}