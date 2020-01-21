import { UserModelItem } from 'src/app/shared/models/user/UserModelItem';
import { BaseModel } from 'src/app/shared/models/Base/BaseModel';

export class UserModel extends BaseModel {

       count:number;
       items:Array<UserModelItem>;
   
      }
