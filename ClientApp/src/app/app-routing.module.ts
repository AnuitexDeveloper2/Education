import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  
    {
      path: 'account',
      loadChildren: () => import('src/app/account/account.module').then(mod =>mod.AccountModule)
    },
    
    {
      path: 'user',
      loadChildren: () => import('src/app/user/user.module').then(mod =>mod.UserModule)
    },
    
    {
      path: 'author',
      loadChildren: () => import('src/app/author/author.module').then(mod =>mod.AuthorModule)
    },

    {
      path: 'books',
      loadChildren: () => import('src/app/printing-edition/printing-edition.module').then(mod =>mod.PrintingEditionModule)
    },

    {
      path: 'administrator',
      loadChildren: () => import('src/app/administrator/administrator.module').then(mod =>mod.AdministratorModule)
    }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
