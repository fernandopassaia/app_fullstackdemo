import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import * as Material from '@angular/material';

// This is a "Central" Angular Material Module and I'll put all the Componentes I'll use here

@NgModule({
    imports: [
        CommonModule,
        //this is the modules from the template        
        Material.MatRippleModule,
        Material.MatTooltipModule,
        Material.MatAutocompleteModule,
        Material.MatButtonToggleModule,
        Material.MatCardModule,
        Material.MatChipsModule,
        Material.MatExpansionModule,
        Material.MatGridListModule,
        Material.MatIconModule,
        Material.MatListModule,
        Material.MatMenuModule,
        Material.MatProgressBarModule,
        Material.MatProgressSpinnerModule,
        Material.MatSidenavModule,
        Material.MatSliderModule,
        Material.MatSlideToggleModule,
        Material.MatTooltipModule,
        Material.MatStepperModule,
        Material.MatNativeDateModule,

        //this i used in fornax sample (modules to grid, search, order, modal)
        Material.MatToolbarModule,
        Material.MatGridListModule,
        Material.MatFormFieldModule,
        Material.MatInputModule,
        Material.MatRadioModule,
        Material.MatSelectModule,
        Material.MatCheckboxModule,
        Material.MatDatepickerModule,
        Material.MatNativeDateModule,
        Material.MatButtonModule,
        Material.MatSnackBarModule,
        Material.MatTableModule,
        Material.MatIconModule,
        Material.MatPaginatorModule,
        Material.MatSortModule,
        Material.MatDialogModule,
        Material.MatTabsModule,
    ],
    exports: [
        //this is the modules from the template        
        Material.MatRippleModule,
        Material.MatTooltipModule,
        Material.MatAutocompleteModule,
        Material.MatButtonToggleModule,
        Material.MatCardModule,
        Material.MatChipsModule,
        Material.MatExpansionModule,
        Material.MatGridListModule,
        Material.MatIconModule,
        Material.MatListModule,
        Material.MatMenuModule,
        Material.MatProgressBarModule,
        Material.MatProgressSpinnerModule,
        Material.MatSidenavModule,
        Material.MatSliderModule,
        Material.MatSlideToggleModule,
        Material.MatTooltipModule,
        Material.MatStepperModule,
        Material.MatNativeDateModule,

        //this i used in fornax sample (modules to grid, search, order, modal)
        Material.MatToolbarModule,
        Material.MatGridListModule,
        Material.MatFormFieldModule,
        Material.MatInputModule,
        Material.MatRadioModule,
        Material.MatSelectModule,
        Material.MatCheckboxModule,
        Material.MatDatepickerModule,
        Material.MatNativeDateModule,
        Material.MatButtonModule,
        Material.MatSnackBarModule,
        Material.MatTableModule,
        Material.MatIconModule,
        Material.MatPaginatorModule,
        Material.MatSortModule,
        Material.MatDialogModule,
        Material.MatTabsModule,
    ],
    declarations: []
})
export class MaterialModule { }
