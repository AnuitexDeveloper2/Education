import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  
    {
      path: 'account',
      loadChildren: () => import('./account/account.module').then(mod =>mod.AccountModule),
    },
    {
      path: 'user',
      loadChildren: () => import('./user/user.module').then(mod =>mod.UserModule)
    },
    {
      path: 'author',
      loadChildren: () => import('./author/author.module').then(mod =>mod.AuthorModule),
    }

  

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
