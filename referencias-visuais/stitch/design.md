---
name: Artisanal Digital Atelier
colors:
  surface: '#f9f9f7'
  surface-dim: '#dadad8'
  surface-bright: '#f9f9f7'
  surface-container-lowest: '#ffffff'
  surface-container-low: '#f4f4f2'
  surface-container: '#eeeeec'
  surface-container-high: '#e8e8e6'
  surface-container-highest: '#e2e3e1'
  on-surface: '#1a1c1b'
  on-surface-variant: '#424754'
  inverse-surface: '#2f3130'
  inverse-on-surface: '#f1f1ef'
  outline: '#727785'
  outline-variant: '#c2c6d6'
  surface-tint: '#005ac2'
  primary: '#0058be'
  on-primary: '#ffffff'
  primary-container: '#2170e4'
  on-primary-container: '#fefcff'
  inverse-primary: '#adc6ff'
  secondary: '#466558'
  on-secondary: '#ffffff'
  secondary-container: '#c8ead9'
  on-secondary-container: '#4c6b5d'
  tertiary: '#755800'
  on-tertiary: '#ffffff'
  tertiary-container: '#936f00'
  on-tertiary-container: '#fffbff'
  error: '#ba1a1a'
  on-error: '#ffffff'
  error-container: '#ffdad6'
  on-error-container: '#93000a'
  primary-fixed: '#d8e2ff'
  primary-fixed-dim: '#adc6ff'
  on-primary-fixed: '#001a42'
  on-primary-fixed-variant: '#004395'
  secondary-fixed: '#c8ead9'
  secondary-fixed-dim: '#adcebe'
  on-secondary-fixed: '#022016'
  on-secondary-fixed-variant: '#2f4d40'
  tertiary-fixed: '#ffdf9a'
  tertiary-fixed-dim: '#f7be1d'
  on-tertiary-fixed: '#251a00'
  on-tertiary-fixed-variant: '#5a4300'
  background: '#f9f9f7'
  on-background: '#1a1c1b'
  surface-variant: '#e2e3e1'
typography:
  headline-lg:
    fontFamily: Inter
    fontSize: 28px
    fontWeight: '600'
    lineHeight: 36px
    letterSpacing: -0.02em
  headline-md:
    fontFamily: Inter
    fontSize: 20px
    fontWeight: '600'
    lineHeight: 28px
    letterSpacing: -0.01em
  title-md:
    fontFamily: Inter
    fontSize: 16px
    fontWeight: '500'
    lineHeight: 24px
  body-md:
    fontFamily: Inter
    fontSize: 14px
    fontWeight: '400'
    lineHeight: 20px
  label-sm:
    fontFamily: Inter
    fontSize: 12px
    fontWeight: '500'
    lineHeight: 16px
    letterSpacing: 0.02em
  mono-sm:
    fontFamily: Inter
    fontSize: 13px
    fontWeight: '400'
    lineHeight: 18px
rounded:
  sm: 0.25rem
  DEFAULT: 0.5rem
  md: 0.75rem
  lg: 1rem
  xl: 1.5rem
  full: 9999px
spacing:
  unit: 4px
  gutter: 24px
  margin-page: 32px
  sidebar-width: 260px
  card-padding: 20px
---

## Brand & Style

The design system is built for a personal, highly organized digital workshop. It evokes a sense of **stability, precision, and craftsmanship**, moving away from "busy" corporate dashboards toward a serene "atelier" aesthetic. The interface is intentionally quiet, allowing the user's 3D models and miniature photography to be the focal point.

The visual style is **Professional Minimalism** with a **Tactile** edge. It leverages generous whitespace and a "soft-touch" materiality—think high-end stationery or a clean architectural studio. Every element is designed to feel secure and personal, emphasizing the physical nature of 3D printing and painting hobbies.

## Colors

The palette is anchored by a warm, off-white foundation that reduces eye strain during long organizational sessions. 

- **Primary Blue (#3b82f6):** A vibrant, high-integrity blue used exclusively for primary actions, active navigation states, and progress indicators.
- **Sage Green (#86a697):** A muted, organic green for success states, completed prints, and "Ready to Paint" status.
- **Muted Amber (#eab308):** Used sparingly for warnings and attention-required states (e.g., missing files). It is non-aggressive to maintain the calm atmosphere.
- **Neutral Background (#f7f7f5):** A soft, linen-like off-white for the main application shell.
- **Pure White (#ffffff):** Reserved for elevated surfaces like cards, panels, and input fields to create a clear "layered" hierarchy.

## Typography

This design system utilizes **Inter** for its modern, neutral character and exceptional legibility at small sizes. 

- **Hierarchy:** Headlines use a semi-bold weight with tight letter-spacing to feel grounded. Body text maintains a standard 14px size for information density without feeling cramped.
- **Contextual Styles:** Labels for file paths or technical metadata use a slightly smaller, tracked-out style to distinguish them from descriptive prose.
- **Alignment:** All text is left-aligned by default to support the structured, list-and-tree nature of file management.

## Layout & Spacing

The layout follows a **Fixed-Fluid Hybrid** model optimized for Windows desktop environments. 

- **Sidebar:** A fixed 260px left navigation provides persistent access to core categories. It uses a "floating" feel with icons and labels vertically aligned.
- **Main Canvas:** A fluid area with a minimum 32px page margin. Content is organized in a responsive grid of cards.
- **Gutter Strategy:** A generous 24px gutter between cards ensures the "airy" atelier feel, preventing the UI from feeling like a cramped spreadsheet.
- **Tree Structures:** Folder hierarchies use 1px thin connector lines in light grey (#e5e7eb) to maintain visual order without adding bulk.

## Elevation & Depth

Hierarchy is established through **Tonal Layering** and **Soft Ambient Shadows**.

- **Level 0 (Background):** The soft off-white (#f7f7f5) serves as the base.
- **Level 1 (Cards/Surfaces):** Pure white (#ffffff) surfaces sit on top with a 1px border (#e5e7eb) and a very soft, diffused shadow (0px 4px 12px rgba(0,0,0,0.03)).
- **Level 2 (Modals/Popovers):** Higher elevation with a more pronounced shadow (0px 8px 24px rgba(0,0,0,0.08)) to focus user attention.
- **Interactive Depth:** Buttons do not use heavy gradients. Instead, they use subtle shifts in background color or a slight "inner-press" shadow on active states to maintain the artisanal, flat-but-tactile feel.

## Shapes

The shape language is defined by **High Radius** corners, creating a friendly and premium hardware-like feel.

- **Primary Cards:** Use `rounded-2xl` (1.5rem / 24px) to emphasize the "object" nature of the collections.
- **Buttons & Inputs:** Use `rounded-lg` (0.5rem / 8px) for a more precise, professional look that fits within the larger card containers.
- **Status Chips:** Use a full pill shape (`rounded-full`) for quick scannability.

## Components

### Buttons
- **Primary:** Solid Blue (#3b82f6) with white text. High-radius, generous horizontal padding.
- **Secondary/Ghost:** No background or a soft grey tint on hover. Used for "Add" actions within cards or sidebar links.

### Sidebar
- Clear vertical list with 24px icons. Active state is indicated by a subtle light blue background pill and a 4px primary blue vertical bar on the far left.

### Cards
- Container for 3D models. Top half is a 16:9 image container with a slight grey background for empty states. Bottom half contains metadata with a clear progress bar for "Painting Status" or "Print Time."

### Folder Trees
- Clean, indented list for file organization. Uses 16px chevron icons for collapse/expand. Connector lines are light grey and 1px wide.

### Search Bar
- A top-anchored, wide input field with a soft-grey border. On focus, the border transitions to Primary Blue with a subtle glow.

### Progress Bars
- 6px height. Background is a light grey; the fill is Primary Blue. For "Completed" states, the fill transitions to Sage Green.