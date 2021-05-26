import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './component/home/home.component';
import { ThirdPartyPersonService } from './service/thirdPartiesService/third-party-person.service';
import { ThirdPartyPersonFormComponent } from './component/third-parties/third-party-person-form/third-party-person-form.component';
import { AboutComponent } from './component/about/about.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { InvoicesComponent } from './component/invoices/invoices.component';
import { ThirdPartyPersonComponent } from './component/third-parties/third-party-person/third-party-person.component';
import { EditThirdPartyPersonComponent } from './component/third-parties/edit-third-party-person/edit-third-party-person.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ThirdPartyPersonComponent,
    ThirdPartyPersonFormComponent,
    AboutComponent,
    EditThirdPartyPersonComponent,
    InvoicesComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'tpperson', component: ThirdPartyPersonComponent},
      { path: 'tpperson/Create', component: ThirdPartyPersonFormComponent},
      { path: 'tpperson/Edit/:id', component: EditThirdPartyPersonComponent},
      { path: 'invs', component: InvoicesComponent},
      { path: 'about', component: AboutComponent}
    ]),
    BrowserAnimationsModule
  ],
  providers: [ThirdPartyPersonService],
  bootstrap: [AppComponent]
})
export class AppModule { }
