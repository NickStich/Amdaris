import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ThirdPartyPersonComponent } from './component/third-party-person/third-party-person.component';
import { ThirdPartyPersonService } from './service/third-party-person.service';
import { ThirdPartyPersonFormComponent } from './component/third-party-person-form/third-party-person-form.component';
import { AboutComponent } from './component/about/about.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ThirdPartyPersonComponent,
    ThirdPartyPersonFormComponent,
    AboutComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'tpperson', component: ThirdPartyPersonComponent},
      { path: 'tpperson/Create', component: ThirdPartyPersonFormComponent},
      { path: 'about', component: AboutComponent}
    ])
  ],
  providers: [ThirdPartyPersonService],
  bootstrap: [AppComponent]
})
export class AppModule { }
