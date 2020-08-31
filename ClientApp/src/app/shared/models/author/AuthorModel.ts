import { AuthorModelItem } from 'src/app/shared/models/author/AuthorModelItem';
import { BaseModel } from 'src/app/shared/models/Base/BaseModel';

export class AuthorModel extends BaseModel {
    count: number;
    items: Array<AuthorModelItem>;
}
