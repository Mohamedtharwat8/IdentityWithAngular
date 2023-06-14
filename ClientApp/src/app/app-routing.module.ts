import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from './shared/components/errors/not-found/not-found.component';
import { RollesComponent } from './rolles/rolles.component';

const routes: Routes = [
  {path:'',component:HomeComponent},
  {path:'rolles',component:RollesComponent},

  //implementing lay loading
  {path:'account',loadChildren:() => import('./account/account.module')
  .then(module => module.AccountModule)},
  {path:'not-found',component:NotFoundComponent},
  {path:'*',component:NotFoundComponent,pathMatch:'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
