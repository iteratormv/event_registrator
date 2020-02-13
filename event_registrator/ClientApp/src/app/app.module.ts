import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { RegitrateformComponent } from './regitrateform/regitrateform.component';
import { EndregistrateComponent } from './regitrateform/endregistrate/endregistrate.component';
import { LoginformComponent } from './loginform/loginform.component';
import { AdministrationComponent } from './administration/administration.component';
import { CabinetComponent } from './cabinet/cabinet.component';
import { CreateeventformComponent } from './createeventform/createeventform.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    RegitrateformComponent,
    EndregistrateComponent,
    LoginformComponent,
    AdministrationComponent,
    CabinetComponent,
    CreateeventformComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'regitrateform', component: RegitrateformComponent },
      { path: 'endregistrate', component: EndregistrateComponent },
      { path: 'loginform', component: LoginformComponent },
      { path: 'administration', component: AdministrationComponent },
      { path: 'cabinet', component: CabinetComponent },
      { path: 'createeventform', component: CreateeventformComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
